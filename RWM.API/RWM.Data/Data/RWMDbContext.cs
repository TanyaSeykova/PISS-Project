using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    }

}
