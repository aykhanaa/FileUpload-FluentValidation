using ELearing_API.Models;
using FileApload_FluentValidation.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearing_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }













       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
