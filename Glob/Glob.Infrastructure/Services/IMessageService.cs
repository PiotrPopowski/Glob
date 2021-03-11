using Glob.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.MessageService;

namespace Glob.Infrastructure.Services
{
    public interface IMessageService
    {
        event MessageReceivedEventHandler MessageReceived;
        void Initialize();
        Task Send(Contact toUser, string message);
        Task<Conversation> GetChatAsync(string user);
        Task<IList<Conversation>> GetAllAsync();
    }
}
