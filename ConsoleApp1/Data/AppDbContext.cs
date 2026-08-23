using ConsoleApp1.Content;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Title).IsRequired();
                entity.Property(x => x.Author).HasMaxLength(200);
                entity.Property(x => x.ContentType).HasConversion<int>();
                entity.Property(x => x.PublishedDate);
                entity.Property(x => x.Body);
            });
        }
    }
}
