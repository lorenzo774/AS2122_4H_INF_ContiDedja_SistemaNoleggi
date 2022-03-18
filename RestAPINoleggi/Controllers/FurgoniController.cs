using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noleggio_Library.DTOs;

namespace RestAPINoleggi.Controllers
{
    [Route("api/furgoni")]
    [ApiController]
    public class FurgoniController : ControllerBase
    {
        private readonly ISQLServerNoleggiRepository sQLServerNoleggiRepository;
        private readonly IMapper mapper;

        public FurgoniController(ISQLServerNoleggiRepository SQLServerNoleggiRepository, IMapper mapper)
        {
            sQLServerNoleggiRepository = SQLServerNoleggiRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Furgone>>> GetAll()
        {
            return Ok(await sQLServerNoleggiRepository.GetAllFurgoniAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Furgone>> Create(FurgoneDTO furgoneDTO)
        {
            if (furgoneDTO is null) return BadRequest();

            var furgone = mapper.Map<Furgone>(furgoneDTO);
            await sQLServerNoleggiRepository.Add(furgone);

            return Ok(furgone);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Furgone>> Get(int id)
        {
            var furgone = await sQLServerNoleggiRepository.GetFurgoneAsync(id);
            if (furgone is null) return NotFound($"Furgone dell'id:{id} non trovato");

            return Ok(furgone);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFurgone(int id)
        {
            await sQLServerNoleggiRepository.RemoveFurgoneAsync(id);
            return Ok();
        }
    }
}
