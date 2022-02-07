using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleAppEFWDNC.DB
{
    public partial class TrainingDbContext : DbContext
    {
        public TrainingDbContext()
        {
        }

        public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branch { get; set; } = null!;
        public virtual DbSet<Student1> Student1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-IG3PIKP2;Database=1st Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student1>(entity =>
            {
                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_Birth");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Marks).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RollNumber).HasColumnName("Roll_number");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Student1)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Student1__Branch__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
