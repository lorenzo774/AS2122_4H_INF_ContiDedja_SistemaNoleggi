namespace Noleggio_Library
{
    public class Automobile : Veicolo, ICsvSerializable
    {
        public int NumeroPosti { get; private set; }

        public Automobile(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, int numeroPosti)
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            NumeroPosti = numeroPosti;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tPosti: {NumeroPosti}";
        }

        public string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera},{NumeroPosti}";
        }

        public ICsvSerializable ObjectFormat(string str)
        {
            string[] data = str.Split(',');
            return new Cliente(data[1], data[2], data[0]);
        }
    }
}