namespace Noleggio_Library
{
    public class Cliente
    {
        public string CF { get; private set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Cliente(string nome, string cognome, string CF)
        {
            Nome = nome;
            Cognome = cognome;
            this.CF = CF;
        }
    }
}