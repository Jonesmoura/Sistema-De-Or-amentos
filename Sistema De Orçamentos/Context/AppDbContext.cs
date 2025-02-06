using Microsoft.EntityFrameworkCore;
using SistemaOrc.Models;

namespace SistemaOrc.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base()
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }

    }
}
