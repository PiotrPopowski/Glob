using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class Message
    {
        public Guid Id { get; protected set; }
        public User Sender { get; protected set; }
        public User Receiver { get; protected set; }
        public string Data { get; protected set; }
        public DateTime SentTime { get; protected set; }

        public Conversation Conversation { get; protected set; }

        public Message(User sender, User receiver, string data, Conversation conversation)
        {
            Id = Guid.NewGuid();
            Sender = sender;
            Receiver = receiver;
            Data = data;
            SentTime = DateTime.Now;
            Conversation = conversation;
        }
        protected Message()
        {
        }
    }
}
