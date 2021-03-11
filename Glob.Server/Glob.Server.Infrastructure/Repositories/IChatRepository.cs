using Glob.Server.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Repositories
{
    public interface IChatRepository
    {
        Task<List<Conversation>> GetAllChats(Guid user);
        Task<Conversation> GetSingleChat(Guid user1, Guid user2);
        Task Add(Conversation chat);
        Task Update(Conversation chat);
    }
}
