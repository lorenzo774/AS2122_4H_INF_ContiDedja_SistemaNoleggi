namespace Noleggio_Library
{
    /// <summary>
    /// Un veicolo genericoq
    /// </summary>
    public class Veicolo : ICsvSerializable
    {
        public int Id { get; set; }
        public string Targa { get; set; }
        public string Modello { get; set; }

        // In SQL decimal(9, 4)
        public decimal CostoVeicolo { get; set; }

        // In SQL decimal(9, 4)
        public decimal TariffaGiornaliera { get; set; }


        public Veicolo(string csvFormat)
        {
        }

        public Veicolo()
        {

        }

        public Veicolo(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera)
        {
            Targa = targa;
            Modello = modello;
            CostoVeicolo = costoVeicolo;
            TariffaGiornaliera = tariffaGiornaliera;
        }

        public override string ToString()
        {
            return $"Id: {Id}\t\tTarga: {Targa}\t\tModello: {Modello}\t\tCosto: {CostoVeicolo}\t\tTariffa: {TariffaGiornaliera}";
        }

        public virtual string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera}";
        }
    }
}