using NoleggiDataAccess_Library.DataAccess;
using Noleggio_Library;

namespace DataAccess_Library
{
    public class SistemaNoleggiDataController
    {
        // Aggiungi un nuovo cliente al db
        public async Task<List<Cliente>> AddCliente(Cliente cliente)
        {
            using (var dbContext = new NoleggiContext())
            {
                dbContext.Clienti.Add(cliente);
                await dbContext.SaveChangesAsync();
                return dbContext.Clienti.ToList();
            }
        }

        // Cerca un cliente per id nel db
        public async Task<Cliente> GetCliente(int id)
        {
            using (var dbContext = new NoleggiContext())
            {
                var cliente = await dbContext.FindAsync<Cliente>(id);
                return cliente;
            }
        }

        // Modifica un cliente per id nel db
        public async Task UpdateCliente(int id, Cliente clienteAggiornato)
        {
            using (var dbContext = new NoleggiContext())
            {
                var cliente = await dbContext.FindAsync<Cliente>(id);
                if(cliente == null) return;

                cliente.Nome = clienteAggiornato.Nome;
                cliente.Cognome = clienteAggiornato.Cognome;
            
                await dbContext.SaveChangesAsync();
            }
        }

        // Rimuovi un cliente per id nel db
        public async Task DeleteCliente(int id)
        {
            using (var dbContext = new NoleggiContext())
            {
                var cliente = await dbContext.FindAsync<Cliente>(id);
                if (cliente == null) return;

                dbContext.Clienti.Remove(cliente);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
