using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Dto
{
    public class ConversationDto
    {
        public ContactDto Contact { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
