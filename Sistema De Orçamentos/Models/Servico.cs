using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaOrc.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }


        [Required(ErrorMessage = "Necessário inseriar a descrição do serviço")]
        [Display(Name = "Descrição do Serviço")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Valor total do orçamento")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }


        public int OrcamentoId { get; set; }
        public virtual Orcamento Orcamento{ get; set; }
    }
}
