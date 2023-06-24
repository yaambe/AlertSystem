
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlertSystem.Models
{
    public partial class PCContext : DbContext
    {
        public PCContext()
        {
        }

        public PCContext(DbContextOptions<PCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<AlertAssign> AlertAssign { get; set; }
        public virtual DbSet<AlertCheck> AlertCheck { get; set; }
        public virtual DbSet<AlertLevel> AlertLevel { get; set; }
        public virtual DbSet<AlertPassengerPicture> AlertPassengerPicture { get; set; }
        public virtual DbSet<AlertStatus> AlertStatus { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.ToTable("Alert", "pc");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Eta)
                    .HasColumnType("datetime")
                    .HasColumnName("ETA");

                entity.Property(e => e.FlightNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FlightScheduledDate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsTroute).HasColumnName("IsTRoute");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.LuggagetagNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.PassengerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlertAssign>(entity =>
            {
                entity.ToTable("AlertAssign", "pc");

                entity.Property(e => e.AlertStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.StaffNotified).HasColumnType("datetime");

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertAssign)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlertAssi__Alert__3F466844");
            });

            modelBuilder.Entity<AlertCheck>(entity =>
            {
                entity.ToTable("AlertCheck", "pc");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlertAssign)
                    .WithMany(p => p.AlertCheck)
                    .HasForeignKey(d => d.AlertAssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlertChec__Alert__4222D4EF");
            });

            modelBuilder.Entity<AlertLevel>(entity =>
            {
                entity.ToTable("AlertLevel", "pc");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Severity).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<AlertPassengerPicture>(entity =>
            {
                entity.ToTable("AlertPassengerPicture", "pc");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AlertStatus>(entity =>
            {
                entity.ToTable("AlertStatus", "pc");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality", "pc");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Nationality1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Nationality");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}