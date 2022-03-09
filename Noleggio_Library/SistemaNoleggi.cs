using System;
using System.Collections.Generic;
using System.Linq;

namespace Noleggio_Library
{
    /// <summary>
    /// Classe principale per il sistema noleggi
    /// </summary>
    public class SistemaNoleggi
    {
        private static SistemaNoleggi instance;
        public static SistemaNoleggi Instance {
            get 
            { 
                if(instance == null)
                {
                    instance = new SistemaNoleggi();
                }
                return instance;
            }
        }

        public List<Veicolo> Veicoli { get; set; }
        public List<Noleggio> Noleggi { get; set; }
        public List<Cliente> Clienti { get; set; }

        /// <summary>Restituisce la lista di automobili presenti nella lista di veicoli</summary>
        public List<Automobile> Automobili { 
            get 
            { 
                return Veicoli.OfType<Automobile>().ToList();
            } 
        }
        /// <summary>Restituisce la lista di furgoni presenti nella lista di veicoli</summary>
        public List<Furgone> Furgoni { 
            get 
            {
                return Veicoli.OfType<Furgone>().ToList();
            } 
        }

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

        /// <param name="cF">Codice fiscale</param>
        public Cliente CercaCliente(string cF)
        {
            return Clienti.FirstOrDefault(v => v.CF == cF);
        }

        /// <param name="cF">Codice fiscale</param>
        public void AggiungiCliente(string nome, string cognome, string cF)
        {
            Clienti.Add(new Cliente(nome, cognome, cF));
        }

        /// <summary>Aggiunge un automobile alla lista di automobili</summary>
        public void AggiungiAutomobile(string targa, string modello, decimal costo, decimal tariffaGiornaliera, int numeroPosti)
        {
            Veicoli.Add(new Automobile(targa, modello, costo, tariffaGiornaliera, numeroPosti));
        }

        /// <summary>Aggiunge un furgone alla lista di furgoni</summary>
        public void AggiungiFurgone(string targa, string modello, decimal costo, decimal tariffaGiornaliera, double capacita)
        {
            Veicoli.Add(new Furgone(targa, modello, costo, tariffaGiornaliera, capacita));
        }

        /// <summary>Aggiunge un furgone alla lista di furgoni</summary>
        public void AggiungiNoleggio(DateTime dataInizio, int durataGiorni, Cliente cliente, Veicolo veicolo)
        {
            Noleggi.Add(new Noleggio(dataInizio, durataGiorni, cliente, veicolo));
        }

        public void RimuoviCliente(Cliente cliente)
        {
            Clienti.Remove(cliente);
        }

        public void RimuoviVeicolo(Veicolo veicolo)
        {
            Veicoli.Remove(veicolo);
        }
        
        public void RimuoviNoleggio(Noleggio noleggio)
        {
            Noleggi.Remove(noleggio);
        }
    }
}