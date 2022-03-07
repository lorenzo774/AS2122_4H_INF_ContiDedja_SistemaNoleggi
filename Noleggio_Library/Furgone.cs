namespace Noleggio_Library
{
    /// <summary>
    /// Furgone, derivato da veicolo
    /// </summary>
    public class Furgone : Veicolo, ICsvSerializable
    {
        public double Capacita { get; private set; }

        public Furgone(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, double capacita) 
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            Capacita = capacita;
        }

        public Furgone(string csvFormat) : base(csvFormat)
        {
            string[] data = csvFormat.Split(',');

            Targa = data[0];
            Modello = data[1];
            TariffaGiornaliera = decimal.Parse(data[2]);
            Capacita = double.Parse(data[3]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tCapacità: {Capacita}kg";
        }

        public string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera},{Capacita}";
        }
    }
}