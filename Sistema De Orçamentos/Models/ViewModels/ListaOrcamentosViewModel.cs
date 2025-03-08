using SistemaOrc.Models.Enums;

namespace SistemaOrc.Models.ViewModels
{
    public class ListaOrcamentosViewModel
    {
        public ICollection<Orcamento> Orcamentos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<string> Status = Enum.GetNames(typeof(OrcamentoStatus)).ToList();

        public string SelectedStatus { get; set; } = null;
    }
}
