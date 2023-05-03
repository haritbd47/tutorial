using Microsoft.EntityFrameworkCore;
using tutorial.Model;

namespace tutorial.Database
{
    public class DataDBcontext : DbContext
    {
        public DataDBcontext(DbContextOptions<DataDBcontext> options):base (options) { }

        public DbSet<manufauturers> manufauturers { get; set; }

        public DbSet<devices> devices { get; set; }
    }
}
