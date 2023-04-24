using InternetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Presistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
