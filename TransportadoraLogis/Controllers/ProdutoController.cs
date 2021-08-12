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
    public class ProdutoController : Controller
    {
        IProdutoServices _service;
        IClienteService _clienteService;


        public ProdutoController(IProdutoServices service, IClienteService clienteService)
        {
            _service = service;
            _clienteService = clienteService;
        }

        public IActionResult Produtos(string cliente, bool ordenado = false)
        {
            ViewBag.totalPedidos = _service.getAll().Count();
            ViewBag.totalQuantidade = _service.getAll().Sum(p => p.Quantidade);
            ViewBag.ordenado = ordenado;
            return View(_service.getAll(cliente, ordenado));    
        }

        [HttpGet]
        public IActionResult Create()
        {
            var clientes = _clienteService.getAll();
            ViewBag.listaClientes = new SelectList(clientes, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto p)
        {
            var clientes = _clienteService.getAll();
            ViewBag.listaClientes = new SelectList(clientes, "Id", "Nome");

            if (!ModelState.IsValid)
            {
                return View(p);
            }
            if (_service.create(p))
                return RedirectToAction(nameof(Produtos));
            else
            {
                return View(p);
            }
        }

        public IActionResult Read(int? id) //possibilita que se crie uma rota específica para determinado id
        {
            Produto produto = _service.get(id);
            return produto != null ?
                View(produto) :
                NotFound();

        }

        public IActionResult Update(int? id)
        {
            var clientes = _clienteService.getAll();
            ViewBag.listaClientes = new SelectList(clientes, "Id", "Nome");
            Produto produto = _service.get(id);
            return produto != null ?
                View(produto) :
                NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Produto produto)
        {
            var clientes = _clienteService.getAll();
            ViewBag.listaClientes = new SelectList(clientes, "Id", "Nome");
            if (!ModelState.IsValid) return View(produto);

            if (_service.update(produto)) //// PacienteStaticService.Create(paciente)
            {
                return RedirectToAction("Produtos");
            }
            else
            {
                return View(produto);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (_service.delete(id)) //// PacienteStaticService.Create(paciente)
            {
                return RedirectToAction(nameof(Produtos));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
