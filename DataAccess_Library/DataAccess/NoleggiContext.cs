using Microsoft.EntityFrameworkCore;
using Noleggio_Library;

namespace NoleggiDataAccess_Library.DataAccess
{
    public class NoleggiContext : DbContext
    {
        private const string connectionString = "";
        private const int decimalPrecision = 18;
        private const int decimalScale = 10;

        public DbSet<Noleggio> Noleggi { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Veicolo> Veicoli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veicolo>()
                        .Property(e => e.TariffaGiornaliera)
                        .HasPrecision(decimalPrecision, decimalScale);
            
            modelBuilder.Entity<Veicolo>()
                        .Property(e => e.CostoVeicolo)
                        .HasPrecision(decimalPrecision, decimalScale);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }
    }
}
