using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class dbDemoContext : DbContext
    {
        public dbDemoContext()
        {
        }

        public dbDemoContext(DbContextOptions<dbDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TProduct> TProducts { get; set; }
        public virtual DbSet<TShoppingCart> TShoppingCarts { get; set; }
        public virtual DbSet<T會員資料> T會員資料s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbDemo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.Fid);

                entity.ToTable("tProduct");

                entity.Property(e => e.Fid).HasColumnName("fid");

                entity.Property(e => e.FCost)
                    .HasColumnType("money")
                    .HasColumnName("fCost");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPrice)
                    .HasColumnType("money")
                    .HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");

                entity.Property(e => e.Fimage)
                    .HasColumnType("image")
                    .HasColumnName("fimage");

                entity.Property(e => e.FimagePath)
                    .HasMaxLength(300)
                    .HasColumnName("fimagePath");
            });

            modelBuilder.Entity<TShoppingCart>(entity =>
            {
                entity.HasKey(e => e.Fid);

                entity.ToTable("tShoppingCart");

                entity.Property(e => e.Fid).HasColumnName("fid");

                entity.Property(e => e.FCustomer).HasColumnName("fCustomer");

                entity.Property(e => e.FDate)
                    .HasMaxLength(50)
                    .HasColumnName("fDate");

                entity.Property(e => e.FProduct).HasColumnName("fProduct");

                entity.Property(e => e.TCount).HasColumnName("tCount");

                entity.Property(e => e.TPrice)
                    .HasColumnType("money")
                    .HasColumnName("tPrice");
            });

            modelBuilder.Entity<T會員資料>(entity =>
            {
                entity.HasKey(e => e.Fid);

                entity.ToTable("t會員資料");

                entity.Property(e => e.Fid).HasColumnName("fid");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fPhone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
