using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPINoleggi.DTOs;

namespace RestAPINoleggi.Controllers
{
    [Route("api/automobili")]
    [ApiController]
    public class AutomobiliController : ControllerBase
    {
        private readonly ISQLServerNoleggiRepository sQLServerNoleggiRepository;
        private readonly IMapper mapper;

        public AutomobiliController(ISQLServerNoleggiRepository SQLServerNoleggiRepository, IMapper mapper)
        {
            sQLServerNoleggiRepository = SQLServerNoleggiRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Automobile>>> GetAll()
        {
            return Ok(await sQLServerNoleggiRepository.GetAllAutomobiliAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Automobile>> Create(AutomobileDTO automobileDTO)
        {
            if (automobileDTO is null) return BadRequest();

            var automobile = mapper.Map<Automobile>(automobileDTO);
            await sQLServerNoleggiRepository.Add(automobile);

            return Ok(automobile);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Automobile>> Get(int id)
        {
            var automobile = await sQLServerNoleggiRepository.GetAutomobileAsync(id);
            if (automobile is null) return NotFound($"Automobile dell'id:{id} non trovato");

            return Ok(automobile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAutomobile(int id)
        {
            await sQLServerNoleggiRepository.RemoveAutomobileAsync(id);
            return Ok();
        }

    }
}
