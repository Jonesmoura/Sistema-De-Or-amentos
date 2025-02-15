namespace SistemaOrc.Models.ViewModels
{
    public class OrcamentoFormViewModel
    {
        public Orcamento Orcamento { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
