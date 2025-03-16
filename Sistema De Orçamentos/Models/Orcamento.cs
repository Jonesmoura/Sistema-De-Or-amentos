using SistemaOrc.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaOrc.Models
{
    [Table("Orcamentos")]
    public class Orcamento
    {
        [Key]
        [Display(Name = "Número do Orçamento")]
        public int OrcamentoId { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Display(Name = "Valor total do orçamento (R$)")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }
        [Display(Name = "Número do Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public List<Servico> Servicos { get; set; }

        public OrcamentoStatus Status { get; set; } = OrcamentoStatus.Pendente;

    }
}
