using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrderApi1.Models
{
    public partial class shopContext : DbContext
    {
        public shopContext()
        {
        }

        public shopContext(DbContextOptions<shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Ordertable> Ordertables { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-330;Database=shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__Customer__049D3E81BD8DA940");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mailid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mailid");

                entity.Property(e => e.Phoneno)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ordertable>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__Ordertab__C39F4017F48CC9F2");

                entity.ToTable("Ordertable");

                entity.Property(e => e.ListofProducts).IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Ordertables)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__Ordertabl__Custo__48CFD27E");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Ordertables)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__Ordertable__Pid__47DBAE45");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__C57059385E1BF080");

                entity.ToTable("Product");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
