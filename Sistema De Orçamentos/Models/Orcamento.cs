using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaOrc.Models
{
    [Table("Orcamentos")]
    public class Orcamento
    {
        [Key]
        public int OrcamentoId { get; set; }
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Valor total do orçamento")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public List<Servico> Servicos { get; set; }

    }
}
