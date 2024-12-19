using CRUD_Task.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Task.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.Property(x => x.Code)
                .HasMaxLength(2); 
                b.HasIndex(x => x.Name)
                    .IsUnique();
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                   .HasMaxLength(128);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
