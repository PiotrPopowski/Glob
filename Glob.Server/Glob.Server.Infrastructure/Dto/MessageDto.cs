using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Dto
{
    public class MessageDto
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Data { get; set; }
        public DateTime SentTime { get; set; }
    }
}
