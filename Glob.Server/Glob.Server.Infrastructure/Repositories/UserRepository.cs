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
    public class UserRepository : IUserRepository
    {
        private readonly GlobContext _context;

        public UserRepository(GlobContext globContext)
        {
            _context = globContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var dbUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            return dbUser;
        }

        public async Task DeleteAsync(User user)
        {
            var dbUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(string login)
        {
            var dbUser = await _context.Users.Include(x => x.AwaitedContacts).Include(x => x.Contacts).SingleOrDefaultAsync(x => x.Login == login);
            return dbUser;
        }

        public async Task AddAwaitedUserAsync(AwaitedUser awaitedUser, User user, User contact)
        {
            _context.AwaitedUsers.Add(awaitedUser);

            contact.AwaitedContacts.Add(awaitedUser);
            contact.Contacts.Add(user);
            _context.Users.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAwaitedUserAsync(params AwaitedUser[] users)
        {
            _context.AwaitedUsers.RemoveRange(users);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
