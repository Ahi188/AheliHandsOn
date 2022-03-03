using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MenuAPI.DB
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

        public virtual DbSet<Dishes> Dishes { get; set; } = null!;
        public virtual DbSet<FoodChoice> FoodChoice { get; set; } = null!;
        public virtual DbSet<MenuCard> MenuCard { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-IG3PIKP2;Database=1st Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.HasKey(e => e.DishId)
                    .HasName("PK__IndianDi__18834F50EA2896D5");

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.DishName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Choice)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.ChoiceId)
                    .HasConstraintName("FK__IndianDis__Choic__31B762FC");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__IndianDis__MenuI__30C33EC3");
            });

            modelBuilder.Entity<FoodChoice>(entity =>
            {
                entity.HasKey(e => e.ChoiceId)
                    .HasName("PK__FoodChoi__76F5168623BDDE54");

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MenuCard>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__MenuCard__C99ED2509E5C1257");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Cusine)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
