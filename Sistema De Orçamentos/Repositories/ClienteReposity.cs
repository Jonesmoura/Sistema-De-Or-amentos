using Microsoft.EntityFrameworkCore;
using SistemaOrc.Context;
using SistemaOrc.Models;
using SistemaOrc.Repositories.Interfaces;

namespace SistemaOrc.Repositories
{
    public class ClienteReposity : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteReposity(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Clientes => _context.Clientes;
        public IEnumerable<Cliente> ClientesAtivos => _context.Clientes.Where(obj => obj.Ativo);

        public Cliente GetClienteById(int id) => _context.Clientes.FirstOrDefault( obj => obj.ClienteId == id);

        public void Insert(Cliente cliente) { 
            _context.Add(cliente);
            _context.SaveChanges();        
        }

    }
}
