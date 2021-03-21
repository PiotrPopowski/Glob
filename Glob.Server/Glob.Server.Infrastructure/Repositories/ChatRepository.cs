using Glob.Server.Core.Contexts;
using Glob.Server.Core.Domain;
using Microsoft.EntityFrameworkCore;
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
        private readonly GlobContext _context;

        public ChatRepository(GlobContext globContext)
        {
            _context = globContext;
        }

        public async Task Add(Conversation chat)
        {
            _context.Conversations.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task AddMessage(Message message, Conversation conversation)
        {
            _context.Messages.Add(message);
            conversation.Messages.Add(message);
            _context.Conversations.Update(conversation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Conversation>> GetAllChats(Guid user)
        {
            var x = await _context.Conversations.Include(p => p.Messages).Where(x => (x.Participant1.Id == user) || (x.Participant2.Id == user)).ToListAsync();
            return x;
        }

        public async Task<Conversation> GetSingleChat(Guid user1, Guid user2)
        {
            var x = await _context.Conversations.Include(p => p.Messages).SingleOrDefaultAsync(
                    x => (x.Participant1.Id == user1 && x.Participant2.Id == user2)
                        || (x.Participant1.Id == user2 && x.Participant2.Id == user1)
                    );
            return x;
        }

        public async Task Update(Conversation chat)
        {
            _context.Conversations.Update(chat);
            await _context.SaveChangesAsync();
        }
    }
}
