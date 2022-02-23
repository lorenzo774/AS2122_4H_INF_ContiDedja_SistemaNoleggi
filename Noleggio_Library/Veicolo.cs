﻿using System.Collections.Generic;
using System;

namespace Noleggio_Library
{
    public class Veicolo
    {
        public string Targa { get; }
        public string Modello { get; }
        public decimal CostoVeicolo { get; set; }
        public decimal TariffaGiornaliera { get; set; }
        public List<Noleggio> Noleggi { get; private set; }

        public Veicolo(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera)
        {
            Targa = targa;
            Modello = modello;
            CostoVeicolo = costoVeicolo;
            TariffaGiornaliera = tariffaGiornaliera;
        }

        public void AggiungiNoleggio(DateTime dataInizio, int durataNoleggio)
        {
            Noleggi.Add(new Noleggio(dataInizio, durataNoleggio));
        }

        public bool Disponibile() { return false; }
        public decimal CalcolaRicavo() { return 0; }
    }
}
