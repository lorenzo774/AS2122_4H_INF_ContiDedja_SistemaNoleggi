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
        public bool Disponibile { get; protected set; }

        // In SQL decimal(9, 4)
        public decimal CostoVeicolo { get; protected set; }

        // In SQL decimal(9, 4)
        public decimal TariffaGiornaliera { get; set; }


        public Veicolo(string csvFormat)
        {
            Disponibile = true;
        }

        public Veicolo()
        {
            Disponibile = true;
        }

        public Veicolo(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera)
        {
            Disponibile = true;
            Targa = targa;
            Modello = modello;
            CostoVeicolo = costoVeicolo;
            TariffaGiornaliera = tariffaGiornaliera;
        }

        public void InvertDisponibilite()
        {
            bool value = Disponibile == true ? false : true;
            Disponibile = value;
        }

        public override string ToString()
        {
            return $"Targa: {Targa}\t\tModello: {Modello}\t\tCosto: {CostoVeicolo}\t\tTariffa: {TariffaGiornaliera}";
        }

        public virtual string CsvFormat()
        {
            return $"{Targa},{Modello},{TariffaGiornaliera},{CostoVeicolo}";
        }
    }
}