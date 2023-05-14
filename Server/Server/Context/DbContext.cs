using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Context
{
    public class DbContexts :DbContext
    {
        public DbContexts(DbContextOptions<DbContexts> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
    }
}
