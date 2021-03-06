using System;
using System.ComponentModel.DataAnnotations;

namespace Noleggio_Library.DTOs
{
    public class NoleggioDTO
    {
        [Required]
        public DateTime DataInizio { get; set; }
    
        [Required]
        public int DurataNoleggio { get; set; }
    
        [Required]
        public int ClienteId { get; set; }
        
        [Required]
        public int VeicoloId { get; set; }

    }
}
