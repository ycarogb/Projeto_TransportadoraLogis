using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Data;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Services
{
    public class ClienteService : IClienteService
    {
        private ProdutoContext _context;

        public ClienteService(ProdutoContext context)
        {
            _context = context;
        }

        public bool create(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                _context.Clientes.Remove(get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  Cliente get(int id)
        {
            return _context.Clientes.FirstOrDefault( p => p.Id == id);
        }
        public List<Cliente> getAll()
        {
            return _context.Clientes.ToList();
        }
        public bool update(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
