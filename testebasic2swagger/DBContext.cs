namespace testebasic
{
    using Microsoft.EntityFrameworkCore;
    using testebasic.Models;

 
        public class AppDbContext : DbContext
        {
            private const string ConnectionString =
                "SSL Mode=VerifyFull;Host=eerie-grebe-3686.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Username=joao;Password=0PBz1qwWNnfda3XWIkpJoQ;Database=ISI";

            public DbSet<Category> Categories { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseNpgsql(ConnectionString);
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>()
                    .ToTable("category", "public")
                    .HasKey(c => c.Id);
            }
        }
    }


