using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Core.Domain
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Data { get; set; }
        public DateTime SentTime { get; set; }

        public Message(string sender, string reciever, string data)
        {
            Sender = sender;
            Receiver = reciever;
            Data = data;
            SentTime = DateTime.Now;
        }
    }
}
