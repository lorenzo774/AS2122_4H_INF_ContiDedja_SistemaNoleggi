namespace Noleggio_Library
{
    /// <summary>
    /// Furgone, derivato da veicolo
    /// </summary>
    public class Furgone : Veicolo
    {
        public double Capacita { get; private set; }

        public Furgone(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, double capacita) 
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            Disponibile = true;
            Capacita = capacita;
        }

        public Furgone()
        {
            Disponibile = true;
        }

        public Furgone(string csvFormat) : base(csvFormat)
        {
            Disponibile = true;
            string[] data = csvFormat.Split(',');

            Targa = data[0];
            Modello = data[1];
            TariffaGiornaliera = decimal.Parse(data[2]);
            CostoVeicolo = decimal.Parse(data[3]);
            Capacita = double.Parse(data[4]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tCapacità: {Capacita}kg";
        }

        public override string CsvFormat()
        {
            return $"{base.CsvFormat()},{Capacita}";
        }
    }
}