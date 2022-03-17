using Microsoft.EntityFrameworkCore;

namespace RestAPINoleggi.Data
{
    public class NoleggiContext : DbContext
    {
        private const int decimalPrecision = 18;
        private const int decimalScale = 10;

        public DbSet<Noleggio> Noleggi { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Automobile> Automobili { get; set; }
        public DbSet<Furgone> Furgoni { get; set; }

        public NoleggiContext(DbContextOptions<NoleggiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veicolo>()
                        .Property(e => e.TariffaGiornaliera)
                        .HasPrecision(decimalPrecision, decimalScale);
            
            modelBuilder.Entity<Veicolo>()
                        .Property(e => e.CostoVeicolo)
                        .HasPrecision(decimalPrecision, decimalScale);
        }
    }
}
