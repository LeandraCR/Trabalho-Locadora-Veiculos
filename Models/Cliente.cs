using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendaVeiculos.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(200)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string? CPF { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        public virtual Endereco? Endereco { get; set; }
        public virtual ICollection<Aluguel>? Alugueis { get; set; }
    }
}