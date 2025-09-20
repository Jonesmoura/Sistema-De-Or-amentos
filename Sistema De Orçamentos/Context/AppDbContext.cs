using Microsoft.EntityFrameworkCore;
using SistemaOrc.Models;

namespace SistemaOrc.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento Orcamento -> Servicos com cascade
            modelBuilder.Entity<Orcamento>()
                .HasMany(o => o.Servicos)
                .WithOne(s => s.Orcamento)
                .HasForeignKey(s => s.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
