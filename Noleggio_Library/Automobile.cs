namespace Noleggio_Library
{
    public class Automobile : Veicolo
    {
        public int NumeroPosti { get; private set; }

        public Automobile(string targa, string modello, decimal costoVeicolo, decimal tariffaGiornaliera, int numeroPosti)
            : base(targa, modello, costoVeicolo, tariffaGiornaliera)
        {
            NumeroPosti = numeroPosti;
        }
    }
}
