using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Data
{
    public class ProdutoContext : IdentityDbContext
    {
        public ProdutoContext (DbContextOptions<ProdutoContext> options) : base (options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.appUser)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);
        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
