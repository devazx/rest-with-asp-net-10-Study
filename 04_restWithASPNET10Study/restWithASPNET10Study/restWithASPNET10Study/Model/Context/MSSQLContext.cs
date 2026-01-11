using Microsoft.EntityFrameworkCore;

namespace restWithASPNET10Study.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) {}
        public DbSet<Users> Users { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
