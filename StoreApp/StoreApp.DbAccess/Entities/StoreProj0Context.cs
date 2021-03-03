using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class StoreProj0Context : DbContext
  {
    public StoreProj0Context()
    {
    }

    public StoreProj0Context(DbContextOptions<StoreProj0Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Inventory> Inventories { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Orderitem> Orderitems { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Customer>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.Balance)
                  .HasColumnType("money")
                  .HasColumnName("balance")
                  .HasDefaultValueSql("((0.00))");

        entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("firstName")
                  .HasDefaultValueSql("('DEFAULT')");

        entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("lastName")
                  .HasDefaultValueSql("('CUSTOMER')");
      });

      modelBuilder.Entity<Inventory>(entity =>
      {
        entity.ToTable("Inventory");

        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.InStock).HasColumnName("in stock");

        entity.Property(e => e.LocationId).HasColumnName("LocationID");

        entity.Property(e => e.ProductId).HasColumnName("productID");

        entity.HasOne(d => d.Location)
                  .WithMany(p => p.Inventories)
                  .HasForeignKey(d => d.LocationId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Inventory__Locat__6442E2C9");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.Inventories)
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Inventory__produ__65370702");
      });

      modelBuilder.Entity<Location>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.Address1)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("address1")
                  .HasDefaultValueSql("('THIS STREET')");

        entity.Property(e => e.Address2)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("address2")
                  .HasDefaultValueSql("('')");

        entity.Property(e => e.City)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("city")
                  .HasDefaultValueSql("('CITYTOWN')");

        entity.Property(e => e.Code)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("code")
                  .HasDefaultValueSql("('')");

        entity.Property(e => e.State)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("state")
                  .HasDefaultValueSql("('STATE')");
      });

      modelBuilder.Entity<Order>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

        entity.Property(e => e.LocationId).HasColumnName("LocationID");

        entity.Property(e => e.TimeOfOrder)
                  .HasColumnName("timeOfOrder")
                  .HasDefaultValueSql("(sysdatetimeoffset())");

        entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(d => d.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Orders__Customer__5AB9788F");

        entity.HasOne(d => d.Location)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(d => d.LocationId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Orders__Location__5CA1C101");
      });

      modelBuilder.Entity<Orderitem>(entity =>
      {
        entity.ToTable("Orderitem");

        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.OrderId).HasColumnName("OrderID");

        entity.Property(e => e.ProductId).HasColumnName("productID");

        entity.Property(e => e.Quantity).HasColumnName("quantity");

        entity.HasOne(d => d.Order)
                  .WithMany(p => p.Orderitems)
                  .HasForeignKey(d => d.OrderId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Orderitem__Order__5F7E2DAC");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.Orderitems)
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Orderitem__produ__607251E5");
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.Description)
                  .HasMaxLength(500)
                  .HasColumnName("description")
                  .HasDefaultValueSql("('DESCRIPTION')");

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("name")
                  .HasDefaultValueSql("('DEFAULT')");

        entity.Property(e => e.Price)
                  .HasColumnType("smallmoney")
                  .HasColumnName("price")
                  .HasDefaultValueSql("((0.00))");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
