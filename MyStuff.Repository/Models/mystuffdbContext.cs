using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyStuff.Repository.Models
{
    public partial class mystuffdbContext : DbContext
    {
        public mystuffdbContext()
        {
        }

        public mystuffdbContext(DbContextOptions<mystuffdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryImage> InventoryImages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=mystuff-db;Username=postgres;Password=1q2w3e");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Indonesian_Indonesia.1252");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Category_UserId_fkey");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Inventory_CategoryId_fkey");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Inventory_LocationId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Inventory_UserId_fkey");
            });

            modelBuilder.Entity<InventoryImage>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryImages)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("InventoryImages_InventoryId_fkey");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Location_UserId_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Birthday).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
