using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Produtos()
        {
            return View(getProduto());
        }
        
        List<Produto> getProduto() //criando um método para retornar a lista estática usada nessa parte do projeto
        {
            List<Produto> listaProduto = new List<Produto>();
            listaProduto.Add(new Produto { Id = 1, Codigo = 0001, Cliente = "Mauro Aguiar", Destino = "São Paulo", DataSaida = new DateTime(2021, 8, 15), Quantidade=3000 });
            listaProduto.Add(new Produto { Id = 2, Codigo = 0002, Cliente = "Poliana Souza", Destino = "Fortaleza", DataSaida = new DateTime(2021, 8, 15), Quantidade = 8000 });
            listaProduto.Add(new Produto { Id = 3, Codigo = 0003, Cliente = "Positron LTDA", Destino = "Manaus", DataSaida = new DateTime(2021, 8, 15), Quantidade = 10000 });
            listaProduto.Add(new Produto { Id = 4, Codigo = 0004, Cliente = "Mauro Aguiar", Destino = "São Paulo", DataSaida = new DateTime(2021, 8, 15), Quantidade = 6000 });
            listaProduto.Add(new Produto { Id = 5, Codigo = 0005, Cliente = "Paula Buffet", Destino = "Rio de Janeiro", DataSaida = new DateTime(2021, 8, 15), Quantidade = 15000 });
            listaProduto.Add(new Produto { Id = 6, Codigo = 0006, Cliente = "Julio Frota", Destino = "Recife", DataSaida = new DateTime(2021, 8, 15), Quantidade = 5000 });
            listaProduto.Add(new Produto { Id = 7, Codigo = 0007, Cliente = "Ana Serafim", Destino = "Curitiba", DataSaida = new DateTime(2021, 8, 15), Quantidade = 10000 });
            listaProduto.Add(new Produto { Id = 8, Codigo = 0008, Cliente = "Maria Doces e Bolos", Destino = "Salvador", DataSaida = new DateTime(2021, 8, 15), Quantidade = 15000 });
            listaProduto.Add(new Produto { Id = 9, Codigo = 0009, Cliente = "Mauro Aguiar", Destino = "São Paulo", DataSaida = new DateTime(2021, 8, 15), Quantidade = 18000 });
            listaProduto.Add(new Produto { Id = 10, Codigo = 0010, Cliente = "Ana Serafim", Destino = "Curitiba", DataSaida = new DateTime(2021, 8, 15), Quantidade = 2500 });
            return listaProduto;
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(Produto p)
        {
            List<Produto> novoProduto = getProduto();
            novoProduto.Add(p);
            p.Id = getProduto().Last().Id + 1;
            p.Codigo = getProduto().Last().Id + 1;
            return View("Produtos", novoProduto);
        }

        public IActionResult Read(int? id) //possibilita que se crie uma rota específica para determinado id
        {
            Produto produto = getProduto().FirstOrDefault(p => p.Id == id); //instanciando um objeto que tenha o id que foi chamado na rota
            return View(produto);

        }

        public IActionResult Update(int? id)
        {
            Produto produto = getProduto().FirstOrDefault(p => p.Id == id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Update (Produto produtoAtualizado)
        {
            List<Produto> listaProduto = getProduto();
            Produto produtoExistente = listaProduto.FirstOrDefault(p => p.Id == produtoAtualizado.Id);
            if (produtoExistente == null) return RedirectToAction("Index");

            int indice = listaProduto.IndexOf(produtoExistente);
            listaProduto[indice] = produtoAtualizado;
            return View("Produtos", listaProduto);
        }

        public IActionResult Remove(int? id)
        {
            var produto = getProduto().Find(p => p.Id == id);
            if (produto != null)
                return View(produto);
            return NotFound();
        }

        
        public IActionResult Delete(int? id)
        {
            List<Produto> listaProduto = getProduto();
            Produto produtoExistente = listaProduto.FirstOrDefault(prod => prod.Id == id);
            listaProduto.Remove(produtoExistente);
            return View("Produtos", listaProduto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
