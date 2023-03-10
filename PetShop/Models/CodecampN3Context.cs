using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Models;

public partial class CodecampN3Context : DbContext
{
    public CodecampN3Context()
    {
    }

    public CodecampN3Context(DbContextOptions<CodecampN3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BannerImage> BannerImages { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<CauHinh> CauHinhs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3213E83FEC331976");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("((0))")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasDefaultValueSql("((0))")
                .HasColumnName("password");
        });

        modelBuilder.Entity<BannerImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banner_i__10373C34A0B391FB");

            entity.ToTable("Banner_image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("((0))")
                .HasColumnName("image");
            entity.Property(e => e.Link)
                .HasDefaultValueSql("((0))")
                .HasColumnName("link");
            entity.Property(e => e.SubTitle)
                .HasDefaultValueSql("((0))")
                .HasColumnName("sub_title");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("((0))")
                .HasColumnName("title");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("((0))")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83FC4A7E192");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("((0))")
                .HasColumnName("name");
            entity.Property(e => e.ParentId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("parentId");
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83FF18F604B");

            entity.ToTable("CategoryProduct");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("categoryId");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("productId");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83FF44DA073");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasDefaultValueSql("((0))")
                .HasColumnName("adress");
            entity.Property(e => e.Avatar)
                .HasDefaultValueSql("((0))")
                .HasColumnName("avatar");
            entity.Property(e => e.ContactNumber)
                .HasDefaultValueSql("((0))")
                .HasColumnName("contactNumber");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("((0))")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.Email)
                .HasDefaultValueSql("((0))")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("((0))")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasDefaultValueSql("((0))")
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((0))")
                .HasColumnName("status");
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83FB2B6A967");

            entity.ToTable("CustomerOrder");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("customerId");
            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orderId");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F58C86865");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeliveryDate)
                .HasDefaultValueSql("((0))")
                .HasColumnType("datetime")
                .HasColumnName("deliveryDate");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("((0))")
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orderStatus");
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(15, 4)")
                .HasColumnName("total");
            entity.Property(e => e.Customer_id)
                .HasDefaultValueSql("((0))")
                .HasColumnName("customer_id");
            entity.Property(e => e.Fullname)
                .HasDefaultValueSql("((0))")
                .HasColumnName("fullname");
            entity.Property(e => e.Address)
                .HasDefaultValueSql("((0))")
                .HasColumnName("address");
            entity.Property(e => e.Telephone)
                .HasDefaultValueSql("((0))")
                .HasColumnName("telephone");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("((0))")
                .HasColumnName("comment");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83F61A2A8E6");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orderId");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("productId");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((0))")
                .HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnName("total");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F66BADC07");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("((0))")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("((0))")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("((0))")
                .HasColumnName("name");
            entity.Property(e => e.OriginalPrice)
                .HasDefaultValueSql("((0))")
                .HasColumnName("originalPrice");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((0))")
                .HasColumnName("price");
            entity.Property(e => e.ProductType)
                .HasDefaultValueSql("((0))")
                .HasColumnName("productType");
            entity.Property(e => e.Specification)
                .HasDefaultValueSql("((0))")
                .HasColumnName("specification");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
