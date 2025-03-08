﻿using Microsoft.AspNetCore.Mvc;
using SistemaOrc.Models;
using SistemaOrc.Models.ViewModels;
using SistemaOrc.Repositories.Interfaces;

namespace SistemaOrc.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        private readonly IClienteRepository _clienteReposity;

        public OrcamentoController(IClienteRepository clienteReposity, IOrcamentoRepository orcamentoRepository)
        {
            _clienteReposity = clienteReposity;
            _orcamentoRepository = orcamentoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var clientes = _clienteReposity.Clientes.OrderBy(obj => obj.Nome).ToList();
            var viewModel = new OrcamentoFormViewModel { Clientes = clientes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Orcamento orcamento)
        {
            //if (!ModelState.IsValid)
            //{
            //    var clientes = _clienteReposity.Clientes.OrderBy(obj => obj.Nome).ToList();
            //    var viewModel = new OrcamentoFormViewModel { Clientes = clientes };
            //    return View(viewModel);
            //}


            TempData["SuccessMessage"] = "Orçamento criado com sucesso!";
            orcamento.Servicos.RemoveAll(s => string.IsNullOrWhiteSpace(s.Descricao) || s.Valor <= 0);
            _orcamentoRepository.Insert(orcamento);
            return RedirectToAction("Create");

        }

        public IActionResult List() 
        {
            var orcamentos = _orcamentoRepository.Orcamentos.OrderBy(obj => obj.DataCriacao).ToList();
            var clientes = _clienteReposity.Clientes.OrderBy(obj => obj.Nome).ToList();

            var viewModel = new ListaOrcamentosViewModel { Clientes = clientes, Orcamentos = orcamentos};
            return View(viewModel);
        }

        public IActionResult Filter(DateTime? dateMin, DateTime? dateMax, string selectedStatus, string cliente)
        {
            var orcamentos = _orcamentoRepository.Orcamentos;

            if (dateMin.HasValue)
            {
                orcamentos = orcamentos.Where(orc => orc.DataCriacao >= dateMin.Value);
                ViewData["DateMin"] = dateMin.Value.ToString("yyyy-MM-dd");
            }
            if (dateMax.HasValue)
            {
                orcamentos = orcamentos.Where(orc => orc.DataCriacao <= dateMax.Value.AddDays(1));
                ViewData["DateMax"] = dateMax.Value.ToString("yyyy-MM-dd");
            }

            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Todos")
            {
                orcamentos = orcamentos.Where(orc => orc.Status.ToString() == selectedStatus);
                ViewData["Status"] = selectedStatus;
            }

            if (!string.IsNullOrEmpty(cliente)) 
            { 
                orcamentos = orcamentos.Where(orc => orc.Cliente.Nome.Contains(cliente));
                ViewData["Cliente"] = cliente;
            }

            var clientes = _clienteReposity.Clientes.OrderBy(obj => obj.Nome).ToList();
            var viewModel = new ListaOrcamentosViewModel { Clientes = clientes, Orcamentos = orcamentos.OrderBy(obj => obj.DataCriacao).ToList() };

            return View("List", viewModel);
        }

    }
}
