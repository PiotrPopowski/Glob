using Glob.Server.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Contexts
{
    public class GlobContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<AwaitedUser> AwaitedUsers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }


        public GlobContext(DbContextOptions<GlobContext> options) : base(options)
        {

        }

    }
}
