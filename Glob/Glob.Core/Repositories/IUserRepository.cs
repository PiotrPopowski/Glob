using Glob.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Get(string login);
        Task Update(User user);
        Task Delete(User user);
    }
}
