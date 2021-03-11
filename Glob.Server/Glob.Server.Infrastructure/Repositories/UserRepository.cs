using Glob.Server.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> users = new HashSet<User>();
        public async Task<User> CreateAsync(User user)
        {
            await Task.FromResult(users.Add(user));
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            var dbUser = users.SingleOrDefault(x => x.Login == user.Login);
            await Task.FromResult(users.Remove(dbUser));
        }

        public async Task<User> GetAsync(string login)
        {
            var dbUser = await Task.FromResult(users.SingleOrDefault(x => x.Login == login));
            return dbUser;
        }

        public async Task UpdateAsync(User user)
        {
            var dbUser = await Task.FromResult(users.SingleOrDefault(x => x.Login == user.Login));
            users.Remove(dbUser);
            users.Add(user);
        }
    }
}
