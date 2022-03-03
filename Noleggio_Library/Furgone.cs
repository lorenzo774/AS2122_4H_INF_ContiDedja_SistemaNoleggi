namespace Noleggio_Library
{
    public class Furgone : Veicolo, ICsvSerializable
    {
        public double Capacita { get; private set; }

        public Furgone(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, double capacita) 
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            Capacita = capacita;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tCapacità: {Capacita}kg";
        }

        public string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera},{Capacita}";
        }

        public ICsvSerializable ObjectFormat(string str)
        {
            string[] data = str.Split(',');
            return new Cliente(data[1], data[2], data[0]);
        }
    }
}