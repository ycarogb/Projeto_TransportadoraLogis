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
                    context.Clientes.Add(new Cliente { Nome = "João Silva", Telefone = "54318955", Cidade = "Salvador", eMail = "xxxx@yy.z", Id = 1 });
                    context.Clientes.Add(new Cliente { Nome = "Amanda Silva", Telefone = "54789622", Cidade = "Recife", eMail = "xxxx@yy.z", Id = 2 });
                    context.Clientes.Add(new Cliente { Nome = "Reinaldo Eletros", Telefone = "98575432", Cidade = "Rio de Janeiro", eMail = "xxxx@yy.z", Id = 3 });
                    context.Clientes.Add(new Cliente { Nome = "Ana Tecidos", Telefone = "54385962", Cidade = "São Paulo", eMail = "xxxx@yy.z", Id = 4 });
                    context.Clientes.Add(new Cliente { Nome = "João Teixeira", Telefone = "58965258", Cidade = "Vitória", eMail = "xxxx@yy.z", Id = 5 });
                }

                if (!context.Produto.Any())
                {
                    context.Produto.Add(new Produto { Codigo = 5432, Destino = "Salvador", DataSaida = new DateTime(2021, 8, 20), Quantidade = 6000, Id = 1, clienteId=1 });
                    context.Produto.Add(new Produto { Codigo = 5432, Destino = "Recife", DataSaida = new DateTime(2021, 8, 15), Quantidade = 7000, Id = 2, clienteId = 2 });
                    context.Produto.Add(new Produto { Codigo = 5432, Destino = "Rio de Janeiro", DataSaida = new DateTime(2021, 8, 6), Quantidade = 6000, Id = 3, clienteId = 3 });
                    context.Produto.Add(new Produto { Codigo = 5432, Destino = "São Paulo", DataSaida = new DateTime(2021, 9, 20), Quantidade = 5500, Id = 4, clienteId = 4 });
                    context.Produto.Add(new Produto { Codigo = 5432, Destino = "Vitória", DataSaida = new DateTime(2021, 8, 21), Quantidade = 8500, Id = 5, clienteId = 5 });
                }


            }

        }
    }
}
