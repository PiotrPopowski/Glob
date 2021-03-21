using AutoMapper;
using Glob.Server.Core.Domain;
using Glob.Server.Infrastructure.Dto;
using Glob.Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository,IChatRepository chatRepository, 
            IJwtHandler jwtHandler, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _jwtHandler = jwtHandler;
            _encrypter = encrypter;
            _mapper = mapper;
        }
        public async Task<JwtDto> Login(string login, string password)
        {
            var user = await _userRepository.GetAsync(login);
            if(user == null)
            {
                throw new Exception("Nie ma takiego użytkownika :(");
            }
            var passwordHash = _encrypter.GetHash(password, user.Salt);
            if (user.PasswordHash != passwordHash)
            {
                throw new Exception("Złe hasło :(");
            }
            var token = _jwtHandler.CreateToken(user.Id, user.Login);
            var userDto = _mapper.Map<UserDto>(user);

            return new JwtDto() { User = userDto, Token = token };
        }

        public async Task Register(string login, string firstName, string lastName, string password, string publicKey)
        {
            var loginExists = await _userRepository.GetAsync(login);
            if(loginExists != null)
            {
                throw new Exception("Login jest już zajęty :(");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            var user = new User(login, firstName, lastName, hash, salt, publicKey);
            await _userRepository.CreateAsync(user);
        }

        public async Task<ContactDto> GetAsync(string login)
        {
            var user = await _userRepository.GetAsync(login);
            if(user == null)
            {
                throw new Exception($"Nie znaleziono użytkownika z loginem {login}");
            }
            return _mapper.Map<ContactDto>(user);
        }

        public async Task<ContactDto> AddContact(string userLogin, string contactLogin, string key, string iv)
        {
            var user = await _userRepository.GetAsync(userLogin);
            var contact = await _userRepository.GetAsync(contactLogin);
            if(contact == null)
            {
                throw new Exception($"Nie znaleziono użytkownika z loginem {contactLogin}");
            }

            user.Contacts.Add(contact);
            await _userRepository.UpdateAsync(user);

            var awaitedUser = new AwaitedUser(user.Login, key, iv);
            await _userRepository.AddAwaitedUserAsync(awaitedUser, user, contact);

            var chat = new Conversation(user, contact);
            await _chatRepository.Add(chat);

            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<List<AwaitedContactDto>> GetNewContacts(string userLogin)
        {
            var user = await _userRepository.GetAsync(userLogin);
            var awaitedUsers = user.AwaitedContacts.ToArray();
            try
            {
                return _mapper.Map<List<AwaitedContactDto>>(awaitedUsers);
            }
            finally
            {
                user.AwaitedContacts.Clear();
                await _userRepository.UpdateAsync(user);
                await _userRepository.RemoveAwaitedUserAsync(awaitedUsers);
            }
        }
    }
}
