
using BackendandAuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendandAuthAPI.Context
{
    public class AppDbContex: DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
