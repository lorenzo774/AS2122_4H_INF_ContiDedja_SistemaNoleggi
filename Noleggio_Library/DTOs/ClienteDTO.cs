using System.ComponentModel.DataAnnotations;

namespace Noleggio_Library.DTOs
{
    public class ClienteDTO
    {
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Cognome { get; set; }

        [Required]
        public string CF { get; set; }
    }
}
