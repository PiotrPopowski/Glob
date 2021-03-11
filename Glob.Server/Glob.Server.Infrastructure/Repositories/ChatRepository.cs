using Glob.Server.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private static List<Conversation> conversations = new List<Conversation>();

        public Task Add(Conversation chat)
        {
            conversations.Add(chat);
            return Task.CompletedTask;
        }

        public async Task<List<Conversation>> GetAllChats(Guid user)
        {
            var x = await Task.FromResult(conversations.FindAll(x => (x.Participant1.Id == user) || (x.Participant2.Id == user)));
            return x;
        }

        public async Task<Conversation> GetSingleChat(Guid user1, Guid user2)
        {
            var x = await Task.FromResult(
                conversations.SingleOrDefault(x => 
                    (x.Participant1.Id == user1 && x.Participant2.Id == user2)
                    || (x.Participant1.Id == user2 && x.Participant2.Id == user1)
                    ));
            return x;
        }

        public async Task Update(Conversation chat)
        {
            var old = await Task.FromResult(conversations.SingleOrDefault(x => x.Id == chat.Id));
            old.Messages.Clear();
            old.Messages.AddRange(chat.Messages);
        }
    }
}
