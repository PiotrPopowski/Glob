using AutoMapper;
using Glob.Server.Core.Domain;
using Glob.Server.Infrastructure.Dto;
using Glob.Server.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChatService(IUserRepository userRepository, IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<ConversationDto>> GetAllChatsAsync(string userLogin)
        {
            var user = await _userRepository.GetAsync(userLogin);
            var chats = await _chatRepository.GetAllChats(user.Id);
            var chatsDto = new List<ConversationDto>();
            foreach(var chat in chats)
            {
                var contact = chat.Participant1.Login == userLogin ? chat.Participant2 : chat.Participant1;
                var chatDto = new ConversationDto()
                {
                    Contact = _mapper.Map<ContactDto>(contact),
                    Messages = _mapper.Map<List<MessageDto>>(chat.Messages)
                };
                chatsDto.Add(chatDto);
            }
            return chatsDto;
        }

        public async Task<ConversationDto> GetChatAsync(string userLogin, string contactLogin)
        {
            var user = await _userRepository.GetAsync(userLogin);
            var contact = await _userRepository.GetAsync(contactLogin);
            if(user == null || contact == null)
            {
                throw new System.Exception("User not found.");
            }
            var chat = await _chatRepository.GetSingleChat(user.Id, contact.Id);

            var chatDto = new ConversationDto()
            {
                Contact = _mapper.Map<ContactDto>(contact),
                Messages = _mapper.Map<List<MessageDto>>(chat.Messages)
            };
            return chatDto;
        }

        public async Task Send(string userLogin, string contactLogin, string message)
        {
            var user = await _userRepository.GetAsync(userLogin);
            var contact = await _userRepository.GetAsync(contactLogin);
            if(user == null || contact == null)
            {
                throw new System.Exception("User not found.");
            }
            var chat = await _chatRepository.GetSingleChat(user.Id, contact.Id);
            var msg = new Message(user, contact, message);
            chat.Messages.Add(msg);
            //await _chatRepository.Update(chat);
        }

        public async Task UpdateChat(Conversation chat)
        {
            await _chatRepository.Update(chat);
        }
    }
}