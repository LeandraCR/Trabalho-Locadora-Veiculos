using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendaVeiculos.Models
{
    [Table("Fabricantes")]
    public class Fabricante
    {
        [Key]
        public int FabricanteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        public virtual ICollection<Veiculo>? Veiculos { get; set; }
    }
}