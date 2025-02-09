﻿using SistemaOrc.Models;

namespace SistemaOrc.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }
        IEnumerable<Cliente> ClientesAtivos { get; }

        Cliente GetClienteById(int id);
        void Insert(Cliente cliente);
    }
}
