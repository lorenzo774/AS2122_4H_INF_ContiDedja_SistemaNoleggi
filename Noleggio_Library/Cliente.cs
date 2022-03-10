namespace Noleggio_Library
{
    public class Cliente : ICsvSerializable
    {
        public int Id { get; set; }
        public string CF { get; private set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cognome, string CF)
        {
            Nome = nome;
            Cognome = cognome;
            this.CF = CF;
        }

        public Cliente(string csvFormat)
        {
            string[] data = csvFormat.Split(',');

            CF = data[0];
            Nome = data[1];
            Cognome = data[2];
        }

        public override string ToString()
        {
            return $"Cognome: {Cognome}\t\tNome: {Nome}\t\tCF: {CF}";
        }

        public string CsvFormat()
        {
            return $"{CF},{Nome},{Cognome}";
        }
    }
}