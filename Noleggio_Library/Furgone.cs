namespace Noleggio_Library
{
    public class Furgone : Veicolo
    {
        public double Capacita { get; private set; }

        public Furgone(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, double capacita) 
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            Capacita = capacita;
        }
    }
}