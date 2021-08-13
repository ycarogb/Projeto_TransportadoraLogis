using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<ProdutoContext>();
                context.Database.Migrate();
                
                if (!context.Clientes.Any())
                {
                    context.Clientes.Add(new Cliente { Nome = "João Silva", Telefone = "54318955", Cidade = "Salvador", eMail = "xxxx@yy.z"});
                    context.Clientes.Add(new Cliente { Nome = "Amanda Silva", Telefone = "54789622", Cidade = "Recife", eMail = "xxxx@yy.z" });
                    context.Clientes.Add(new Cliente { Nome = "Reinaldo Eletros", Telefone = "98575432", Cidade = "Rio de Janeiro", eMail = "xxxx@yy.z"});
                    context.Clientes.Add(new Cliente { Nome = "Ana Tecidos", Telefone = "54385962", Cidade = "São Paulo", eMail = "xxxx@yy.z"});
                    context.Clientes.Add(new Cliente { Nome = "João Teixeira", Telefone = "58965258", Cidade = "Vitória", eMail = "xxxx@yy.z"});
                }

                context.SaveChanges();


            }

        }
    }
}
