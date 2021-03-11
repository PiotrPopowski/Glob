using Glob.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.UI.Infrastructure
{
    public class ChatMessage
    {
        public Bubble.MessageType Type { get; set; }
        public string Data { get; set; }
        public string Time { get; set; }
    }
}
