namespace Noleggio_Library
{
    /// <summary>
    /// Un veicolo generico
    /// </summary>
    public class Veicolo
    {
        protected string targa, modello;
        public string Targa { get { return targa; } }
        public string Modello { get { return modello; } }
        public decimal CostoVeicolo { get; }
        public decimal TariffaGiornaliera { get; set; }
        public bool Disponibile { get; private set; }


        public Veicolo(string csvFormat)
        {
        }

        public Veicolo(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera)
        {
            this.targa = targa;
            this.modello = modello;
            CostoVeicolo = costoVeicolo;
            TariffaGiornaliera = tariffaGiornaliera;
        }

        public override string ToString()
        {
            return $"Targa: {Targa}\t\tModello: {Modello}\t\tCosto: {CostoVeicolo}\t\tTariffa: {TariffaGiornaliera}\t\tDisponibile: {(Disponibile ? "✔️" : "❌")}";
        }
    }
}