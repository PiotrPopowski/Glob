using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Core.Domain
{
    public class Conversation
    {
        public Contact Contact { get; protected set; }
        public IList<Message> Messages { get; protected set; } = new List<Message>();

        public Conversation(Contact contact)
        {
            Contact = contact;
        }

        protected Conversation() { }

    }
}
