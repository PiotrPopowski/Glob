using Glob.Server.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetAsync(string login);
        Task AddAwaitedUserAsync(AwaitedUser awaitedUser, User user, User contact);
        Task RemoveAwaitedUserAsync(params AwaitedUser[] users);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
