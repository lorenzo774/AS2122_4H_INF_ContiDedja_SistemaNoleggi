using System.ComponentModel.DataAnnotations;

namespace RestAPINoleggi.DTOs
{
    public class ClienteDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
    }
}
