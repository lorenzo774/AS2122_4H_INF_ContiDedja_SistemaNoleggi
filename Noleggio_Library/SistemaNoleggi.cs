using System.Collections.Generic;
using System.Linq;

namespace Noleggio_Library
{
    public class SistemaNoleggi
    {
        public List<Veicolo> Veicoli { get; private set; }
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
        public List<Cliente> Clienti { get; private set; }

        public Veicolo CercaVeicolo(string targa)
        {
            return Veicoli.FirstOrDefault(v => v.Targa == targa);
        }

        public void AddAutomobile()
        {

        }
    }
}
