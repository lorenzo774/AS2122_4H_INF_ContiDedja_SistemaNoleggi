using System;

namespace Noleggio_Library
{
    public class Noleggio
    {
        static private int idIndex = 0;

        public int Id { get; private set; }
        public DateTime DataInizio { get; set; }
        public int DurataNoleggio { get; set; }

        public Noleggio(DateTime dataInizio, int durataNoleggio)
        {
            this.DataInizio = dataInizio;
            this.DurataNoleggio = durataNoleggio;
            Id = idIndex++;
        }

        public decimal CalcolaCosto() { return 0; }
    }
}