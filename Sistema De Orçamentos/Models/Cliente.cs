using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaOrc.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome do cliente deve ser informado")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(80, MinimumLength = 8, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O número de celular deve ser informado")]
        [Display(Name = "Número de Celular")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Formato invalido, seguir o seguinte formato: 00 00000-0000 ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [Display(Name = "Endereço de E-mail do cliente")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado")]
        [Display(Name = "CEP do cliente")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Formato do cep invalido, seguir o seguinte formato: 00000-000")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O número deve ser informado")]
        [Display(Name = "Número do imóvel")]
        [Column(TypeName = "int(6)")]
        public int Numero { get; set; }

        public bool Ativo { get; set; }

        public List<Orcamento> Orcamentos { get; set; }

    }
}
