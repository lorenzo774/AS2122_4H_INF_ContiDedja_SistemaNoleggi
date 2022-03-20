using System.Collections.Generic;
using System.Linq;

namespace Noleggio_Library
{
    /// <summary>Classe principale per il sistema noleggi</summary>
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

        public bool IsDatabaseSynchronized { get; set; }

        public List<Veicolo> Veicoli { get; set; }
        public List<Noleggio> Noleggi { get; set; }
        public List<Cliente> Clienti { get; set; }

        /// <summary>Restituisce la lista di automobili presenti nella lista di veicoli</summary>
        public List<Automobile> Automobili { 
            get 
            { 
                return Veicoli.OfType<Automobile>().ToList();
            }
            set { }
        }

        /// <summary>Restituisce la lista di furgoni presenti nella lista di veicoli</summary>
        public List<Furgone> Furgoni { 
            get 
            {
                return Veicoli.OfType<Furgone>().ToList();
            }
            set { }
        }

        public SistemaNoleggi()
        {
            Clienti = new List<Cliente>();
            Noleggi = new List<Noleggio>();
            Veicoli = new List<Veicolo>();
        }


        /// <summary>Restituisce un veicolo dalla lista veicoli attraverso una targa</summary>
        public Veicolo CercaVeicolo(string targa)
        {
            return Veicoli.FirstOrDefault(v => v.Targa == targa);
        }

        /// <summary>Restituisce un cliente dalla lista clienti attraverso un codice fiscale</summary>
        public Cliente CercaCliente(string cF)
        {
            return Clienti.FirstOrDefault(v => v.CF == cF);
        }

        /// <summary>Aggiunge un cliente alla lista di clienti</summary>
        public void AggiungiCliente(Cliente cliente)
        {
            Clienti.Add(cliente);
        }

        /// <summary>Aggiunge un automobile alla lista di automobili</summary>
        public void AggiungiAutomobile(Automobile automobile)
        {
            Veicoli.Add(automobile);
        }

        /// <summary>Aggiunge un furgone alla lista di furgoni</summary>
        public void AggiungiFurgone(Furgone furgone)
        {
            Veicoli.Add(furgone);
        }

        /// <summary>Aggiunge un furgone alla lista di furgoni</summary>
        public void AggiungiNoleggio(Noleggio noleggio)
        {
            Noleggi.Add(noleggio);
        }

        /// <summary>Rimuove un cliente dalla lista di clienti</summary>
        public void RimuoviCliente(Cliente cliente)
        {
            Clienti.Remove(cliente);
        }

        /// <summary>Rimuove un veicolo dalla lista di veicoli</summary>
        public void RimuoviVeicolo(Veicolo veicolo)
        {
            Veicoli.Remove(veicolo);
        }
        
        /// <summary>Rimuove un noleggio dalla lista di noleggi</summary>
        public void RimuoviNoleggio(Noleggio noleggio)
        {
            Noleggi.Remove(noleggio);
        }
    }
}