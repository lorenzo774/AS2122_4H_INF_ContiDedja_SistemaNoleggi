using System;

namespace Noleggio_Library
{
    public class Noleggio : ICsvSerializable
    {
        static private int id = 0;

        public int Id { get; private set; }
        public DateTime DataInizio { get; set; }
        public int DurataNoleggio { get; set; }
        public Cliente Cliente { get; private set; }
        public Veicolo Veicolo { get; private set; }


        public Noleggio(DateTime dataInizio, int durataNoleggio, Cliente cliente, Veicolo veicolo)
        {
            this.DataInizio = dataInizio;
            this.DurataNoleggio = durataNoleggio;
            this.Cliente = cliente;
            this.Veicolo = veicolo;
            Id = id++;
        }

        public Noleggio() { }

        public Noleggio(string csvFormat)
        {
            string[] data = csvFormat.Split(',');

            Id = int.Parse(data[0]);
            Veicolo = SistemaNoleggi.Instance.CercaVeicolo(data[1]);
            Cliente = SistemaNoleggi.Instance.CercaCliente(data[2]);
            DataInizio = DateTime.Parse(data[3]);
            DurataNoleggio = int.Parse(data[4]);
        }


        public decimal CalcolaRicavo()
        {
            return Veicolo.TariffaGiornaliera * DurataNoleggio;
        }

        public decimal CalcolaCosto() { return 0; }

        public override string ToString()
        {
            return $"id: {Id}\t\tInizio: {DataInizio}\t\tDurata: {DurataNoleggio}\t\tCliente: {Cliente.Nome}\t\tVeicolo: {Veicolo.Targa}";
        }

        public string CsvFormat()
        {
            return $"{Id},{Veicolo.Targa},{Cliente.CF},{DataInizio.ToString()},{DurataNoleggio.ToString()},{CalcolaCosto().ToString()}";
        }
    }
}