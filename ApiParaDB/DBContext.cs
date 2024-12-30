namespace testebasic2swagger
{
    using Microsoft.EntityFrameworkCore;
    using testebasic2swagger.Models;

    public class AppDbContext : DbContext
        {
            private const string ConnectionString =
                "SSL Mode=VerifyFull;Host=eerie-grebe-3686.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Username=joao;Password=0PBz1qwWNnfda3XWIkpJoQ;Database=ISI";

            public DbSet<Category> Categories { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Product> Products { get; set; }

            public DbSet<Inventory> Inventories { get; set; }
            
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

                modelBuilder.Entity<User>()
                    .ToTable("users", "public")
                    .HasKey(c => c.Id);

                modelBuilder.Entity<Product>()
                    .ToTable("product", "public")
                    .HasKey(c => c.Id);

                modelBuilder.Entity<Inventory>()
                    .ToTable("inventory", "public")
                    .HasKey(c => c.Id);
            }
        }
    }


