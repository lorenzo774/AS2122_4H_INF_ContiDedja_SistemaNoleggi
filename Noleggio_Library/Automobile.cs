﻿namespace Noleggio_Library
{
    /// <summary>
    /// Automobile, derivato da veicolo
    /// </summary>
    public class Automobile : Veicolo
    {
        public int NumeroPosti { get; private set; }

        public Automobile(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, int numeroPosti)
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            Disponibile = true;
            NumeroPosti = numeroPosti;
        }

        public Automobile() 
        {
            Disponibile = true;
        }

        public Automobile(string csvFormat) : base(csvFormat)
        {
            Disponibile = true;
            string[] data = csvFormat.Split(',');

            Targa = data[0];
            Modello = data[1];
            TariffaGiornaliera = decimal.Parse(data[2]);
            CostoVeicolo = decimal.Parse(data[3]);
            NumeroPosti = int.Parse(data[4]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t\tPosti: {NumeroPosti}";
        }

        public override string CsvFormat()
        {
            return $"{base.CsvFormat()},{NumeroPosti}";
        }
    }
}