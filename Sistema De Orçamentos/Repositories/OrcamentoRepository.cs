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

        public Orcamento GetOrcamentoById(int id) => _context.Orcamentos.Include(obj => obj.Servicos).Include(obj => obj.Cliente).FirstOrDefault(obj => obj.OrcamentoId == id);

        public void Insert(Orcamento orcamento)
        {
            _context.Add(orcamento);
            _context.SaveChanges();
        }

        public void Edit(Orcamento orcamento, int[] servicosExcluidos)
        {
            if (servicosExcluidos != null && servicosExcluidos.Length > 0)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var servicoId in servicosExcluidos)
                        {
                            var servico = _context.Servicos.Find(servicoId);
                            if (servico != null)
                            {
                                _context.Servicos.Remove(servico);
                            }
                        }
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            _context.Update(orcamento);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orcamento = GetOrcamentoById(id);
            _context.Remove(orcamento);
            _context.SaveChanges();
        }

    }
}
