using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext (DbContextOptions<ProdutoContext> options) : base (options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

    }
}
