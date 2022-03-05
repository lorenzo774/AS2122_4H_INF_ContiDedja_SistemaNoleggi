namespace Noleggio_Library
{
    /// <summary>
    /// Automobile, derivato da veicolo
    /// </summary>
    public class Automobile : Veicolo, ICsvSerializable
    {
        public int NumeroPosti { get; private set; }

        public Automobile(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, int numeroPosti)
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            NumeroPosti = numeroPosti;
        }

        public Automobile(string csvFormat) : base(csvFormat)
        {
            string[] data = csvFormat.Split(',');

            targa = data[0];
            modello = data[1];
            TariffaGiornaliera = decimal.Parse(data[2]);
            NumeroPosti = int.Parse(data[3]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tPosti: {NumeroPosti}";
        }

        public string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera.ToString()},{NumeroPosti.ToString()}";
        }
    }
}