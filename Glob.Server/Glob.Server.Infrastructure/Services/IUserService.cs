using Glob.Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Services
{
    public interface IUserService
    {
        Task Register(string login, string firstName, string lastName, string password, string publicKey);
        Task<JwtDto> Login(string login, string password);
        Task<ContactDto> AddContact(string userLogin, string contactLogin, string key, string iv);
        Task<ContactDto> GetAsync(string login);
        Task<List<AwaitedContactDto>> GetNewContacts(string userLogin);
    }
}
