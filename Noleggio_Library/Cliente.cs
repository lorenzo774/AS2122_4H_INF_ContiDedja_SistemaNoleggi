namespace Noleggio_Library
{
    public class Cliente : ICsvSerializable
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

        public override string ToString()
        {
            return $"Cognome: {Cognome}\t\tNome: {Nome}\t\tCF: {CF}";
        }

        public string CsvFormat()
        {
            return $"{CF},{Nome},{Cognome}";
        }
        
        public ICsvSerializable ObjectFormat(string str)
        {
            string[] data = str.Split(',');
            return new Cliente(data[1], data[2], data[0]);
        }
    }
}