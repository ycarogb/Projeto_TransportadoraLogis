using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Services
{
        public interface IProdutoServices
        {
            bool create(Produto produto);
            bool delete(int? id);
            Produto get(int? id);
            List<Produto> getAll(string cliente = null, bool ordenado = false);
            bool update(Produto p);
        }
}
