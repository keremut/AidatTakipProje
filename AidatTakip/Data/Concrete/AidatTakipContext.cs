using AidatTakip.Data.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace AidatTakip.Data.Concrete
{
    public class AidatTakipContext : DbContext
    {
        public AidatTakipContext(DbContextOptions<AidatTakipContext> options): base(options)
        {

        }

        public DbSet<Site> Siteler { get; set; }
        public DbSet<Apartman> Apartmanlar { get; set; }
        public DbSet<Daire> Daireler { get; set; }
        public DbSet<Aidat> Aidatlar { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aidat>()
                .HasIndex(a => new { a.DaireId, a.Ay, a.Yil })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
