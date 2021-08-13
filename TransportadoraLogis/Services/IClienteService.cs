using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Services
{
    public interface IClienteService
    {
        public bool create(Cliente cliente);
        public bool delete(int id);
        public Cliente get(int id);
        public List<Cliente> getAll(string busca= null, bool ordenado=false);
        public bool update(Cliente cliente);
    }
}
