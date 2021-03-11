using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class Conversation
    {
        public Guid Id { get; protected set; }
        public User Participant1 { get; protected set; }
        public User Participant2 { get; protected set; }

        public List<Message> Messages { get; protected set; } = new List<Message>();

        public Conversation(User p1, User p2)
        {
            Id = Guid.NewGuid();
            Participant1 = p1;
            Participant2 = p2;
        }

        protected Conversation()
        {
        }
    }
}
