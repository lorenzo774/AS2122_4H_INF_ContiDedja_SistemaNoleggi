using Microsoft.AspNetCore.Mvc;
using RestAPINoleggi.DTOs;

namespace RestAPINoleggi.Controllers
{
    [ApiController]
    [Route("api/noleggi")]
    public class NoleggiController : ControllerBase
    {
        private readonly ISQLServerNoleggiRepository sQLServerNoleggiRepository;
        private readonly IMapper mapper;

        public NoleggiController(ISQLServerNoleggiRepository SQLServerNoleggiRepository, IMapper mapper)
        {
            sQLServerNoleggiRepository = SQLServerNoleggiRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Noleggio>>> GetAll()
        {
            return Ok(await sQLServerNoleggiRepository.GetAllNoleggiAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Noleggio>> Create(NoleggioDTO noleggioDTO)
        {
            if (noleggioDTO is null) return BadRequest();

            var noleggio = mapper.Map<Noleggio>(noleggioDTO);
            await sQLServerNoleggiRepository.Add(noleggio);
            
            return Ok(noleggio);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Noleggio>> Get(int id)
        {
            var noleggio = await sQLServerNoleggiRepository.GetNoleggioAsync(id);
            if (noleggio is null) return NotFound($"Noleggio dell'id:{id} non trovato");

            return Ok(noleggio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveNoleggio(int id)
        {
            await sQLServerNoleggiRepository.RemoveNoleggioAsync(id);
            return Ok();
        }
    }
}