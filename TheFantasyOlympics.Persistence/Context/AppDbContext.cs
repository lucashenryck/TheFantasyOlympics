using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Medal> Medals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.Property(a => a.Id).HasColumnOrder(1);

                entity.Property(a => a.Name).HasColumnOrder(2);
            });

            modelBuilder.Entity<Modality>(entity =>
            {
                entity.Property(a => a.Id).HasColumnOrder(1);

                entity.Property(a => a.Name).HasColumnOrder(2);

                entity.Property(m => m.Type)
                    .HasConversion<string>();

                entity.Property(m => m.Genre)
                    .HasConversion<string>(); 
            });

            modelBuilder.Entity<Medal>(entity =>
            {
                entity.Property(m => m.Position)
                    .HasConversion<string>();
            });

            modelBuilder.Entity<Modality>()
                .HasOne(m => m.Sport)
                .WithMany(s => s.Modalities)
                .HasForeignKey(m => m.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Athlete>()
                .HasOne(a => a.Sport)
                .WithMany()
                .HasForeignKey(a => a.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Athlete>()
                .HasOne(a => a.Modality)
                .WithMany()
                .HasForeignKey(a => a.ModalityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Medal>()
                .HasOne(m => m.Sport)
                .WithMany()
                .HasForeignKey(m => m.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Medal>()
                .HasOne(m => m.Modality)
                .WithMany()
                .HasForeignKey(m => m.ModalityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
