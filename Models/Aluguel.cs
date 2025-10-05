using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendaVeiculos.Models
{
    [Table("Alugueis")]
    public class Aluguel
    {
        [Key]
        public int AluguelId { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        public DateTime? DataDevolucao { get; set; }
        [Required]
        public double QuilometragemInicial { get; set; }
        public double? QuilometragemFinal { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDiaria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorTotal { get; set; }
        
        [ForeignKey("Cliente")]
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        
        [ForeignKey("Veiculo")]
        [Required]
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; } = null!;
    }
}