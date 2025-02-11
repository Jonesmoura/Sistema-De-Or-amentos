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

        public IActionResult Edit(int? id)
        {
            if (id == null || _clienteReposity.Clientes == null) 
            { 
                return NotFound();
            }

            var cliente = _clienteReposity.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Cliente cliente)
        {
            _clienteReposity.Edit(id, cliente);
            TempData["SuccessMessage"] = "Cliente alterado com sucesso!";
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || _clienteReposity.Clientes == null)
            {
                return NotFound();
            }
            var cliente = _clienteReposity.GetClienteById(id);
            return View(cliente);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _clienteReposity.Delete(id);
            TempData["SuccessMessage"] = "Cliente Excluído!";

            return RedirectToAction("List");

        }
    }
}
