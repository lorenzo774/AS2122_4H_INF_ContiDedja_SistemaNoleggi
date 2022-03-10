using Microsoft.AspNetCore.Mvc;
using RestAPINoleggi.DTOs;

namespace RestAPINoleggi.Controllers
{
    [ApiController]
    [Route("api/automobili")]
    public class VeicoliController : ControllerBase
    {
        private readonly ILogger<VeicoliController> _logger;
        private List<Veicolo> veicoli;

        public VeicoliController(ILogger<VeicoliController> logger)
        {
            _logger = logger;
            veicoli = new() { 
                new Automobile() { Id = 1, TariffaGiornaliera = 2 }, 
                new Automobile() { Id = 2, TariffaGiornaliera = 10 }, 
                new Automobile() { Id = 3, TariffaGiornaliera = 3 },
            };

        }

        [HttpGet]
        public async Task<ActionResult<List<AutomobileDTO>>> GetAutomobili()
        {
            if (veicoli.OfType<Automobile>() is null) return NotFound("Automobili non trovati");

            return Ok(veicoli.OfType<Automobile>().Select(v => v.AsDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutomobileDTO>> GetAutomobile(int id)
        {
            var result = veicoli.OfType<Automobile>()
                                .FirstOrDefault(veicoli => veicoli.Id == id);
            
            if (result is null) return NotFound("Automobile non trovata");
            return Ok(result.AsDTO());
        }

        [HttpPost]
        public async Task<ActionResult<Automobile>> CreateAutomobile(AutomobileDTO automobile)
        {
            if (automobile is null) return BadRequest();
            var automobileBO = automobile.AsBO();

            veicoli.Add(automobileBO);
            return Ok(automobileBO);
        }
    }
}