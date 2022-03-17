using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio_Library
{
    public class Noleggio : ICsvSerializable
    {
        public int Id { get; set; }
        public DateTime DataInizio { get; set; }
        public int DurataNoleggio { get; set; }

        public int ClienteId { get; set; }
        public int VeicoloId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        
        [ForeignKey("VeicoloId")]
        public virtual Veicolo Veicolo { get; set; }


        public Noleggio(DateTime dataInizio, int durataNoleggio, Cliente cliente, Veicolo veicolo)
        {
            this.DataInizio = dataInizio;
            this.DurataNoleggio = durataNoleggio;
            this.Cliente = cliente;
            this.Veicolo = veicolo;
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