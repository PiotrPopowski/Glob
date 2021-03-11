using Glob.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public interface IMessageBroker
    {
        Task Send(Contact to, string message);
    }
}
