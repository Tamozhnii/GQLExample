using Microsoft.EntityFrameworkCore;
using GQLExample.Models;

namespace GQLExample.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Shade> Shades { get; set; }
    }
}