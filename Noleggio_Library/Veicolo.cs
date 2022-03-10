namespace Noleggio_Library
{
    /// <summary>
    /// Un veicolo generico
    /// </summary>
    public abstract class Veicolo : ICsvSerializable
    {
        public int Id { get; set; }
        public string Targa { get; protected set; }
        public string Modello { get; protected set; }

        // In SQL decimal(9, 4)
        public decimal CostoVeicolo { get; }

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
            return $"Targa: {Targa}\t\tModello: {Modello}\t\tCosto: {CostoVeicolo}\t\tTariffa: {TariffaGiornaliera}";
        }

        public virtual string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera}";
        }
    }
}