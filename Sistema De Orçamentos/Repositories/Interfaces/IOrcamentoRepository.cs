using SistemaOrc.Models;

namespace SistemaOrc.Repositories.Interfaces
{
    public interface IOrcamentoRepository
    {
        IEnumerable<Orcamento> Orcamentos { get; }
        Orcamento GetOrcamentoById(int id);
    }
}
