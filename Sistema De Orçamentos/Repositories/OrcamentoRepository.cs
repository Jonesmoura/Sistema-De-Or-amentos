using Microsoft.EntityFrameworkCore;
using SistemaOrc.Context;
using SistemaOrc.Models;
using SistemaOrc.Repositories.Interfaces;

namespace SistemaOrc.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly AppDbContext _context;

        public OrcamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Orcamento> Orcamentos => _context.Orcamentos.Include(obj => obj.Cliente);

        public Orcamento GetOrcamentoById(int id) => _context.Orcamentos.FirstOrDefault(obj => obj.OrcamentoId == id);
    }
}
