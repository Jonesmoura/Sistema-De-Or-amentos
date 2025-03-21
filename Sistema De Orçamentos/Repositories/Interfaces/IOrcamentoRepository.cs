﻿using SistemaOrc.Models;

namespace SistemaOrc.Repositories.Interfaces
{
    public interface IOrcamentoRepository
    {
        IEnumerable<Orcamento> Orcamentos { get; }
        Orcamento GetOrcamentoById(int id);

        void Insert(Orcamento orcamento);

        void Edit(Orcamento orcamento, int[] servicosExcluidos);
        public void Delete(int id);

    }
}
