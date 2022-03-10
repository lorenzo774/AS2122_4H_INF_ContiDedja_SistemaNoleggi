using System.ComponentModel.DataAnnotations;

namespace RestAPINoleggi.DTOs
{
    /// <summary>
    /// Interfaccia per implementare un DTO di un veicolo
    /// </summary>
    public interface IVeicoloDTO
    {
        [Required]
        public string Targa { get; set; }
        [Required]
        public string Modello { get; set; }
    
        [Required]
        [DataType("decimal(10, 18)")]
        public decimal CostoVeicolo { get; set; }

        [Required]
        [DataType("decimal(10, 18)")]
        public decimal TariffaGiornaliera { get; set; }
    }
}
