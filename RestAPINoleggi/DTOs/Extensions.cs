namespace RestAPINoleggi.DTOs
{
    public static class Extensions
    {
        public static ClienteDTO AsDTO(this Cliente cliente)
        {
            return new () { 
                Cognome = cliente.Cognome,
                Nome = cliente.Nome 
            };
        }

        public static AutomobileDTO AsDTO(this Automobile automobile)
        {
            return new() { 
                CostoVeicolo = automobile.CostoVeicolo,
                Modello = automobile.Modello, 
                NumeroPosti = automobile.NumeroPosti,
                Targa = automobile.Targa,
                TariffaGiornaliera = automobile.TariffaGiornaliera
            };
        }

        public static Automobile AsBO(this AutomobileDTO automobile)
        {
            return new(
                automobile.Targa, 
                automobile.Modello, 
                automobile.CostoVeicolo, 
                automobile.TariffaGiornaliera, 
                automobile.NumeroPosti
            );
        }

        public static FurgoneDTO AsDTO(this Furgone furgone)
        {
            return new()
            {
                CostoVeicolo = furgone.CostoVeicolo,
                Modello = furgone.Modello,
                Capacita = furgone.Capacita,
                Targa = furgone.Targa,
                TariffaGiornaliera = furgone.TariffaGiornaliera
            };
        }

    }
}
