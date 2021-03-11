using System.Collections.Generic;

namespace Glob.Server.Infrastructure.Dto
{
    public class UserDto
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublicKey { get; set; }
        public string Token { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
        public IEnumerable<AwaitedContactDto> AwaitedContacts { get; set; }
    }
}
