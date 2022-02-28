using System;

namespace Noleggio_Library
{
    public class Noleggio
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


        public decimal CalcolaRicavo()
        {
            return Veicolo.TariffaGiornaliera * DurataNoleggio;
        }

        public decimal CalcolaCosto() { return 0; }

        public override string ToString()
        {
            return $"{Id} {Cliente} {Veicolo}";
        }

    }
}