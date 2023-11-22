using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RicksRentals.Models;

namespace RicksRentals.Data
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bike> Bike { get; set; } = null!;
        public virtual DbSet<Rollerblades> Rollerblades { get; set; } = null!;
        public virtual DbSet<Skateboard> Skateboard { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.Brand)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRate).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Model)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RentalDate).HasColumnType("date");
            });

            modelBuilder.Entity<Rollerblades>(entity =>
            {
                entity.HasKey(e => e.BladesId)
                    .HasName("PK__Rollerbl__D1A9B3202A7EFF4C");

                entity.Property(e => e.Brand)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRate).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Model)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RentalDate).HasColumnType("date");
            });

            modelBuilder.Entity<Skateboard>(entity =>
            {
                entity.HasKey(e => e.SkateId)
                    .HasName("PK__Skateboa__A889436232DC026B");

                entity.Property(e => e.Brand)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRate).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Model)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RentalDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
