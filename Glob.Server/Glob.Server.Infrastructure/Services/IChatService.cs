using Glob.Server.Core.Domain;
using Glob.Server.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Services
{
    public interface IChatService
    {
        Task<ConversationDto> GetChatAsync(string userLogin, string contactLogin);
        Task<List<ConversationDto>> GetAllChatsAsync(string userLogin);
        Task UpdateChat(Conversation chat);
        Task Send(string userLogin, string contactLogin, string message);
    }
}
