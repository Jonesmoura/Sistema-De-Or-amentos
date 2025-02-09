using Microsoft.AspNetCore.Mvc;
using SistemaOrc.Models;
using SistemaOrc.Repositories.Interfaces;

namespace SistemaOrc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteReposity;

        public ClienteController(IClienteRepository clienteReposity)
        {
            _clienteReposity = clienteReposity;
        }

        //criar a view, popular dados para os testes.

        public IActionResult List() 
        { 
            var clientes = _clienteReposity.Clientes;
            return View(clientes);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        { 
            _clienteReposity.Insert(cliente);
            TempData["SuccessMessage"] = "Cliente cadastrado com sucesso!";
            return RedirectToAction("List");

        }  
    }
}
