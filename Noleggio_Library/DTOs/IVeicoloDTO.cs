using System.ComponentModel.DataAnnotations;

namespace Noleggio_Library.DTOs
{
    /// <summary>
    /// Interfaccia per implementare un DTO di un veicolo
    /// </summary>
    public interface IVeicoloDTO
    {
        [Required]
        string Targa { get; set; }
        [Required]
        string Modello { get; set; }
    
        [Required]
        [DataType("decimal(10, 18)")]
        decimal CostoVeicolo { get; set; }

        [Required]
        [DataType("decimal(10, 18)")]
        decimal TariffaGiornaliera { get; set; }
    }
}
