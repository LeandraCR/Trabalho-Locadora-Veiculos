using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendaVeiculos.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        [StringLength(200)]
        public string Logradouro { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Numero { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Complemento { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Bairro { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;
        [Required]
        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;
        [Required]
        [StringLength(8)]
        public string CEP { get; set; } = string.Empty;
        
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        // Alteração: Voltámos a colocar o '?'
        public virtual Cliente? Cliente { get; set; }
    }
}