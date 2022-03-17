
namespace RestAPINoleggi.Repositories
{
    public interface ISQLServerNoleggiRepository
    {
        Task Add(object obj);
        Task<List<Automobile>> GetAllAutomobiliAsync();
        Task<List<Cliente>> GetAllClientiAsync();
        Task<List<Furgone>> GetAllFurgoniAsync();
        Task<List<Noleggio>> GetAllNoleggiAsync();
        Task<Automobile> GetAutomobileAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<Furgone> GetFurgoneAsync(int id);
        Task<Noleggio> GetNoleggioAsync(int id);
        Task UpdateAutomobileAsync(Automobile automobile, int id);
        Task UpdateClienteAsync(Cliente cliente, int id);
        Task UpdateFurgoneAsync(Furgone cliente, int id);
        Task UpdateNoleggioAsync(Noleggio cliente, int id);
        Task RemoveNoleggioAsync(int id);
        Task RemoveClienteAsync(int id);
        Task RemoveFurgoneAsync(int id);
        Task RemoveAutomobileAsync(int id);

    }
}