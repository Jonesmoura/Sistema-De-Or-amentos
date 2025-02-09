using SistemaOrc.Context;
using SistemaOrc.Models;
using SistemaOrc.Repositories.Interfaces;

namespace SistemaOrc.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servico> Servicos => _context.Servicos;

        public Servico GetServicoById(int id) => _context.Servicos.FirstOrDefault(obj => obj.ServicoId == id);
    }
}
