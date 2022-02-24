using System;
using System.Collections.Generic;
using System.Linq;

namespace Noleggio_Library
{
    public class SistemaNoleggi
    {
        public List<Veicolo> Veicoli { get; private set; }
        public List<Noleggio> Noleggi { get; private set; }
        public List<Cliente> Clienti { get; private set; }

        /*
         public List<Noleggio> Noleggi {
            get 
            {
                var noleggi = new List<Noleggio>();
                foreach (Veicolo v in Veicoli)
                {
                    foreach (Noleggio n in v.Noleggi)
                    {
                        noleggi.Add(n);
                    }
                }
                return noleggi;
            }  }
        */

        public SistemaNoleggi()
        {
            Clienti = new List<Cliente>();
            Noleggi = new List<Noleggio>();
            Veicoli = new List<Veicolo>();
        }


        public Veicolo CercaVeicolo(string targa)
        {
            return Veicoli.FirstOrDefault(v => v.Targa == targa);
        }

        public Cliente CercaCliente(string cF)
        {
            return Clienti.FirstOrDefault(v => v.CF == cF);
        }

        public void AggiungiCliente(string nome, string cognome, string cF)
        {
            Clienti.Add(new Cliente(nome, cognome, cF));
        }

        public void AggiungiAutomobile(string targa, string modello, decimal costo, decimal tariffaGiornaliera, int numeroPosti)
        {
            Veicoli.Add(new Automobile(targa, modello, costo, tariffaGiornaliera, numeroPosti));
        }

        public void AggiungiFurgone(string targa, string modello, decimal costo, decimal tariffaGiornaliera, double capacita)
        {
            Veicoli.Add(new Furgone(targa, modello, costo, tariffaGiornaliera, capacita));
        }

        public void AggiungiNoleggio(string targa, string cF, int durataGiorni, DateTime dataInizio)
        {
            Cliente cliente = CercaCliente(cF);
            Veicolo veicolo = CercaVeicolo(targa);
            Noleggi.Add(new Noleggio(dataInizio, durataGiorni, cliente, veicolo));
        }
    }
}