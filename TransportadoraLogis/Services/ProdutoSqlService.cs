using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Data;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Services
{
    public class ProdutoSqlService : IProdutoServices
    {
        ProdutoContext context;

        public ProdutoSqlService(ProdutoContext context)
        {
            this.context = context;
        }

        public List<Produto> getAll(string cliente = null, bool ordenado = false)
        {
            List<Produto> lista = context.Produto.Include(c => c.cliente).ToList();
            if (cliente != null)
            {
                return lista.FindAll(a =>
                    a.cliente.Nome.ToLower().Contains(cliente.ToLower())
                );
            }

            if (ordenado)
            {
                lista = lista.OrderBy(p => p.cliente.Nome).ToList();
                return lista;
            }
            return lista;
        }

        public Produto get(int? id)
        {
            return context.Produto.Find(id);
        }

        public bool create(Produto produto)
        {
            try
            {
                context.Produto.Add(produto);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(Produto produto)
        {
            try
            {
                context.Produto.Update(produto);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int? id)
        {
            try
            {
                context.Produto.Remove(get(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
