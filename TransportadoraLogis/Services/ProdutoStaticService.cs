using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Data;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Services
{
    public class ProdutoStaticService
    {
        public List<Produto> getProduto() //criando um método para retornar a lista estática usada nessa parte do projeto
        {
            List<Produto> listaProduto = new List<Produto>();
            listaProduto.Add(new Produto { Id = 4, Destino = "São Paulo", DataSaida = new DateTime(2021, 8, 15), Quantidade = 6000 });
            listaProduto.Add(new Produto { Id = 5, Destino = "Rio de Janeiro", DataSaida = new DateTime(2021, 8, 15), Quantidade = 15000 });
            listaProduto.Add(new Produto { Id = 6, Destino = "Recife", DataSaida = new DateTime(2021, 8, 15), Quantidade = 5000 });
            listaProduto.Add(new Produto { Id = 7, Destino = "Curitiba", DataSaida = new DateTime(2021, 8, 15), Quantidade = 10000 });
            listaProduto.Add(new Produto { Id = 8, Destino = "Salvador", DataSaida = new DateTime(2021, 8, 15), Quantidade = 15000 });
            listaProduto.Add(new Produto { Id = 9, Destino = "São Paulo", DataSaida = new DateTime(2021, 8, 15), Quantidade = 18000 });
            listaProduto.Add(new Produto { Id = 10,Destino = "Curitiba", DataSaida = new DateTime(2021, 8, 15), Quantidade = 2500 });
            return listaProduto;
        }
        public List<Produto> getAll(string cliente = null, bool ordenado = false) //READ
        {
            if (cliente != null)
            {
                return getProduto().FindAll(a =>
                    a.cliente.Nome.ToLower().Contains(cliente.ToLower())
                );
            }

            if (ordenado)
            {
                return getProduto().OrderBy(p => p.cliente.Nome).ToList();
            }

            return getProduto();
        }

        public Produto get(int? id) //possibilita que se crie uma rota específica para determinado id
        {
            return getProduto().FirstOrDefault(p => p.Id == id); //instanciando um objeto que tenha o id que foi chamado na rota

        }



        //public bool Inserir(Produto produto)
        //{
        //    try
        //    {
        //        List<Produto> produtos = getProduto();
        //        produto.Id = produtos.Count() + 1;
        //        produtos.Add(produto);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

        //public Produto Update(int? id)
        //{
        //    Produto produto = getProduto().FirstOrDefault(p => p.Id == id);
        //    return produto;
        //}

        //public bool UpdateProduto(Produto produtoAtualizado)
        //{
        //    List<Produto> listaProduto = getProduto();
        //    Produto produtoExistente = listaProduto.FirstOrDefault(p => p.Id == produtoAtualizado.Id);
        //    if (produtoExistente == null) return false;

        //    int indice = listaProduto.IndexOf(produtoExistente);
        //    listaProduto[indice] = produtoAtualizado;
        //    return true;
        //}

        //public bool Remove(int? id)
        //{
        //    var produto = getProduto().Find(p => p.Id == id);
        //    if (produto != null)
        //        return true;
        //    return false;
        //}


        //public bool Delete(int? id)
        //{
        //    try
        //    {
        //        List<Produto> listaProduto = getProduto();
        //        Produto produtoExistente = listaProduto.FirstOrDefault(prod => prod.Id == id);
        //        listaProduto.Remove(produtoExistente);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}