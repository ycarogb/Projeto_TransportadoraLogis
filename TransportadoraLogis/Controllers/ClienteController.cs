using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;
using TransportadoraLogis.Services;

namespace TransportadoraLogis.Controllers
{
    public class ClienteController : Controller
    {
        IClienteService _service;
        IProdutoServices _produtoService;

        public ClienteController(IClienteService service, IProdutoServices produtoService)
        {
            _service = service;
            _produtoService = produtoService;
        }

        public IActionResult Clientes(string busca, bool ordenado)
        {
            return View(_service.getAll(busca, ordenado));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if(!ModelState.IsValid) return View(cliente);

            return _service.create(cliente) ?
                RedirectToAction(nameof(Clientes)) :
                View(cliente);
        }

        public IActionResult Read(int id) //possibilita que se crie uma rota específica para determinado id
        {
            Cliente Cliente = _service.get(id);
            return Cliente != null ?
                View(Cliente) :
                NotFound();

        }

        public IActionResult Update(int id)
        {           
            Cliente Cliente = _service.get(id);
            return Cliente != null ?
                View(Cliente) :
                NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Cliente Cliente)
        {
            if (!ModelState.IsValid) return View(Cliente);

            if (_service.update(Cliente)) //// PacienteStaticService.Create(paciente)
            {
                return RedirectToAction(nameof(Clientes));
            }
            else
            {
                return View(Cliente);
            }
        }

        public IActionResult Delete(int id)
        {
            if (_service.delete(id)) //// PacienteStaticService.Create(paciente)
            {
                return RedirectToAction(nameof(Clientes));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
