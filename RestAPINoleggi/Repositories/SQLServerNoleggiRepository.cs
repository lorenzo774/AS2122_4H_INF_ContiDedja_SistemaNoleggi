using RestAPINoleggi.DTOs;
using Microsoft.EntityFrameworkCore;
using RestAPINoleggi.Data;
using System.Linq;

namespace RestAPINoleggi.Repositories
{
    public class SQLServerNoleggiRepository : ISQLServerNoleggiRepository
    {
        private readonly NoleggiContext dataContext;

        public SQLServerNoleggiRepository(NoleggiContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // Add method
        public async Task Add(object obj)
        {
            await dataContext.AddAsync(obj);
            await dataContext.SaveChangesAsync();
        }

        #region Get by id

        public async Task<Noleggio> GetNoleggioAsync(int id)
        {
            return await dataContext.Noleggi.FindAsync(id);
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await dataContext.Clienti.FindAsync(id);
        }

        public async Task<Automobile> GetAutomobileAsync(int id)
        {
            return await dataContext.Automobili.FindAsync(id);
        }

        public async Task<Furgone> GetFurgoneAsync(int id)
        {
            return await dataContext.Furgoni.FindAsync(id);
        }

        #endregion

        #region Update by id

        public async Task UpdateClienteAsync(Cliente cliente, int id)
        {
            var oldCliente = await dataContext.Clienti.FindAsync(id);
            oldCliente = cliente;
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAutomobileAsync(Automobile automobile, int id)
        {
            var oldAutomobile = await dataContext.Automobili.FindAsync(id);
            oldAutomobile = automobile;
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateFurgoneAsync(Furgone furgone, int id)
        {
            var oldFurgone = await dataContext.Furgoni.FindAsync(id);
            oldFurgone = furgone;
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateNoleggioAsync(Noleggio noleggio, int id)
        {
            var oldNoleggio = await dataContext.Noleggi.FindAsync(id);
            oldNoleggio = noleggio;
            await dataContext.SaveChangesAsync();
        }

        #endregion

        #region Get All

        public async Task<List<Noleggio>> GetAllNoleggiAsync()
        {
            return await dataContext.Noleggi.ToListAsync();
        }

        public async Task<List<Automobile>> GetAllAutomobiliAsync()
        {
            return await dataContext.Automobili.ToListAsync();
        }

        public async Task<List<Furgone>> GetAllFurgoniAsync()
        {
            return await dataContext.Furgoni.ToListAsync();
        }

        public async Task<List<Cliente>> GetAllClientiAsync()
        {
            return await dataContext.Clienti.ToListAsync();
        }

        #endregion

        #region Remove by id

        public async Task RemoveNoleggioAsync(int id)
        {
            var noleggio = await dataContext.Noleggi.FindAsync(id);
            if(noleggio is null) return;
            dataContext.Noleggi.Remove(noleggio);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveClienteAsync(int id)
        {
            var cliente = await dataContext.Clienti.FindAsync(id);
            if (cliente is null) return;
            dataContext.Clienti.Remove(cliente);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveFurgoneAsync(int id)
        {
            var furgone = await dataContext.Furgoni.FindAsync(id);
            if (furgone is null) return;
            dataContext.Furgoni.Remove(furgone);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveAutomobileAsync(int id)
        {
            var autombile = await dataContext.Automobili.FindAsync(id);
            if (autombile is null) return;
            dataContext.Automobili.Remove(autombile);
            await dataContext.SaveChangesAsync();
        }

        #endregion

    }
}
