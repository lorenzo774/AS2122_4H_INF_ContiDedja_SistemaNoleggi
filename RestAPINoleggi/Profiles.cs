using Noleggio_Library.DTOs;

namespace RestAPINoleggi
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Noleggio, NoleggioDTO>();
            CreateMap<NoleggioDTO, Noleggio>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Automobile, AutomobileDTO>();
            CreateMap<AutomobileDTO, Automobile>();
            CreateMap<Furgone, FurgoneDTO>();
            CreateMap<FurgoneDTO, Furgone>();
        }
    }
}
