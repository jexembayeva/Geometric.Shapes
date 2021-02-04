using Microsoft.EntityFrameworkCore;
using Models.Shapes;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Shape> Shapes { get; set; }
    }
}
