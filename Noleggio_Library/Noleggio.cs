﻿using System;

namespace Noleggio_Library
{
    public class Noleggio
    {
        static private int idIndex = 0;

        public int Id { get; private set; }
        public DateTime DataInizio { get; set; }
        public int DurataNoleggio { get; set; }
        public Cliente Cliente { get; private set; }
        public Veicolo Veicolo { get; private set; }

        public Noleggio(Cliente cliente, Veicolo veicolo, DateTime dataInizio, int durataNoleggio)
        {
            this.DataInizio = dataInizio;
            this.DurataNoleggio = durataNoleggio;
            this.Cliente = cliente;
            this.Veicolo = veicolo;
            Id = idIndex++;
        }

        public decimal CalcolaCosto()
        {
            return 0;
        }
        public decimal CalcolaRicavo()
        {
            return Veicolo.TariffaGiornaliera * DurataNoleggio;
        }
    }
}