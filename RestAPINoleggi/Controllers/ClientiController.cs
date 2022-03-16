using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPINoleggi.DTOs;

namespace RestAPINoleggi.Controllers
{
    [Route("api/clienti")]
    [ApiController]
    public class ClientiController : ControllerBase
    {
        private readonly ISQLServerNoleggiRepository sQLServerNoleggiRepository;
        private readonly IMapper mapper;

        public ClientiController(ISQLServerNoleggiRepository SQLServerNoleggiRepository, IMapper mapper)
        {
            sQLServerNoleggiRepository = SQLServerNoleggiRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return Ok(await sQLServerNoleggiRepository.GetAllClientiAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(ClienteDTO clienteDTO)
        {
            if (clienteDTO is null) return BadRequest();

            var cliente = mapper.Map<Cliente>(clienteDTO);
            await sQLServerNoleggiRepository.Add(cliente);

            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await sQLServerNoleggiRepository.GetClienteAsync(id);
            if (cliente is null) return NotFound($"Cliente dell'id:{id} non trovato");

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCliente(int id)
        {
            await sQLServerNoleggiRepository.RemoveClienteAsync(id);
            return Ok();
        }
    }
}
