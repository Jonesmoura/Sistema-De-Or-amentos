using SistemaOrc.Models;

namespace SistemaOrc.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        IEnumerable<Servico> Servicos { get; }
        Servico GetServicoById(int id);
    }
}
