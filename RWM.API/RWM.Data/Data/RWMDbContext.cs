using Microsoft.EntityFrameworkCore;
using RWM.Data.Models;

namespace RWM.Data.Data
{
    public class RWMDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public RWMDbContext()
        {
        }

        public RWMDbContext(DbContextOptions<RWMDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Data Source=localhost, 1433; Initial Catalog=Testing;User ID=sa;Password=1234!!PasswordD;Trust Server Certificate=true");
            }
        }
    }

    

}
