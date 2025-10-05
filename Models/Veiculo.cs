using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendaVeiculos.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int AnoFabricacao { get; set; }

        [Required]
        public double Quilometragem { get; set; }

        [ForeignKey("Fabricante")]
        [Required]
        public int FabricanteId { get; set; }

        public virtual Fabricante Fabricante { get; set; } = null!;
        public virtual ICollection<Aluguel>? Alugueis { get; set; }
    }
}