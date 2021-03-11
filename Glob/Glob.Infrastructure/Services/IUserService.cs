using Glob.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public interface IUserService
    {
        User User { get; }
        Task Register(string login, string firstName, string lastName, string password);
        Task<User> Login(string login, string password);
        Task<Contact> AddContact(string login);
        Task<User> Refresh();
    }
}
