
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class ApplicationDbContext : DbContext
{

    private readonly IConfiguration _configuration;
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

        optionsBuilder.UseSqlServer(" Server=localhost,1433;Database=shoppe;User Id=sa;Password=Test@123;Encrypt=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountEntity>(entity =>
        {
            entity.ToTable("Account");
            entity.HasKey(e => e.acc_id);
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(e => e.user_id);
            entity.HasOne(d => d.Account)
               .WithOne(p => p.User)
               .HasForeignKey<UserEntity>(d => d.acc_id);
        });

        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.ToTable("Category");
            entity.HasKey(e => e.Id).HasName("category_id");
            entity.Property(e => e.Id).HasColumnName("category_id");

            entity.HasOne(d => d.Account)
               .WithMany(p => p.ListCategory)
               .HasForeignKey(d => d.created_by);

        });

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.ToTable("Product");
            entity.HasKey(e => e.Id).HasName("product_id");
            entity.Property(e => e.Id).HasColumnName("product_id");

            entity.HasOne(d => d.Category)
               .WithMany(p => p.ListProduct)
               .HasForeignKey(d => d.category_id)
               .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.Account)
               .WithMany(p => p.ListProduct)
               .HasForeignKey(d => d.created_by);
        });

        modelBuilder.Entity<ProductDetailEntity>(entity =>
        {
            entity.ToTable("ProductDetail");
            entity.HasKey(e => e.product_detail_id);

            entity.HasOne(d => d.Product)
               .WithMany(p => p.ListProductDetail)
               .HasForeignKey(d => d.product_id);
        });


    }
}