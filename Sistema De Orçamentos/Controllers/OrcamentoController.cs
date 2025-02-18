using Microsoft.AspNetCore.Mvc;
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
    }
}
