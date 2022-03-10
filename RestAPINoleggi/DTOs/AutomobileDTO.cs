using System.ComponentModel.DataAnnotations;

namespace RestAPINoleggi.DTOs
{
    /// <summary>
    /// DTO dell'automobile
    /// </summary>
    public class AutomobileDTO : IVeicoloDTO
    {
        [Required]
        public string Targa { get; set; } = string.Empty;
        [Required]
        public string Modello { get; set; } = string.Empty;
        
        [Required]
        [DataType("decimal(10, 18)")]
        public decimal CostoVeicolo { get; set; }

        [Required]
        [DataType("decimal(10, 18)")]
        public decimal TariffaGiornaliera { get; set; }

        [Required]
        public int NumeroPosti { get; init; }
    }
}
