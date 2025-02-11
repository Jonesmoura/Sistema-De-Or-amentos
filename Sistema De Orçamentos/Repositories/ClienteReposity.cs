using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public Cliente GetClienteById(int? id) => _context.Clientes.FirstOrDefault( obj => obj.ClienteId == id);

        public void Insert(Cliente cliente) { 
            _context.Add(cliente);
            _context.SaveChanges();        
        }

        public void Edit(int id, Cliente cliente) 
        {
            bool hasCliente = _context.Clientes.Any(x => x.ClienteId == id);
            if (!hasCliente)
            {
                throw new Exception("Id não encontrado");
            }
            
            _context.Update(cliente); // @to-do
            _context.SaveChanges();
        }

        public void Delete(int id)
        { 
            var cliente = _context.Clientes.FirstOrDefault(obj => obj.ClienteId == id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();            
        }

    }
}
