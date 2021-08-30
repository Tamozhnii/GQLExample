using Microsoft.EntityFrameworkCore;
using GQLExample.Models;

namespace GQLExample.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Shade> Shades { get; set; }
        public DbSet<Brightness> Brightnesses { get; set; }
        public DbSet<Saturation> Saturations { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder
                .Entity<Color>()
                .HasOne(c => c.Brightness)
                .WithMany(c => c.Colors)
                .HasForeignKey(c => c.BrightnessId);

            modelBuilder
                .Entity<Color>()
                .HasOne(c => c.Saturation)
                .WithMany(c => c.Colors)
                .HasForeignKey(c => c.SaturationId);

            modelBuilder
                .Entity<Saturation>()
                .HasMany(s => s.Colors)
                .WithOne(s => s.Saturation!)
                .HasForeignKey(s => s.SaturationId);

            modelBuilder
                .Entity<Brightness>()
                .HasMany(b => b.Colors)
                .WithOne(b => b.Brightness!)
                .HasForeignKey(b => b.BrightnessId);
        }
    }
}