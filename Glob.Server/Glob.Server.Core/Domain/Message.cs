using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class Message
    {
        public User Sender { get; protected set; }
        public User Receiver { get; protected set; }
        public string Data { get; protected set; }
        public DateTime SentTime { get; protected set; }

        public Message(User sender, User receiver, string data)
        {
            Sender = sender;
            Receiver = receiver;
            Data = data;
            SentTime = DateTime.Now;
        }
        protected Message()
        {
        }
    }
}
