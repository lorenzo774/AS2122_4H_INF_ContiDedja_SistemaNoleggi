namespace Noleggio_Library
{
    /// <summary>
    /// Un veicolo generico
    /// </summary>
    public class Veicolo
    {
        public string Targa { get; }
        public string Modello { get; }
        public decimal CostoVeicolo { get; set; }
        public decimal TariffaGiornaliera { get; set; }
        public bool Disponibile { get; private set; }

        public Veicolo(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera)
        {
            Targa = targa;
            Modello = modello;
            CostoVeicolo = costoVeicolo;
            TariffaGiornaliera = tariffaGiornaliera;
        }

        public override string ToString()
        {
            return $"Targa: {Targa}\t\tModello: {Modello}\t\tCosto: {CostoVeicolo}\t\tTariffa: {TariffaGiornaliera}\t\tDisponibile: {(Disponibile ? "✔️" : "❌")}";
        }
    }
}