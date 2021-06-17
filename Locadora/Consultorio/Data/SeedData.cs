using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Data
{
    public static class SeedData
    {
        //Seed para preencher o banco de dados caso esteja vazio.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            string[] titulos = new string[] {"Assassinato", "de", "do", "da", "O", "Morte", "Pedra", "Faca", "Princesa", "Sonifero", "Com", "as", "tarde", "muito", "cedo", "dificil", "matar", "sobrevivente"};
            int quantidade = 50;

            using (var context = new LocadoraContext(
                    serviceProvider.GetRequiredService<DbContextOptions<LocadoraContext>>()
                ))
            {
                if (context.Filme.Any())
                {
                    return;
                }

                for (int i = 0; i < quantidade; i++)
                {
                    Random aleatorio = new Random();
                    var dataLancamento = new DateTime(1960, 1, 1);
                    int range = (DateTime.Today - dataLancamento).Days;

                    context.Filme.Add(
                        new Filme()
                        {
                            Titulo = $"{titulos[aleatorio.Next(titulos.Length)]} {titulos[aleatorio.Next(titulos.Length)]} {titulos[aleatorio.Next(titulos.Length)]} " +
                            $" {titulos[aleatorio.Next(titulos.Length)]} ",
                            DataLancamento = dataLancamento.AddDays(aleatorio.Next(range)),
                            Duracao = aleatorio.Next(2, 250),
                            Preco = aleatorio.Next(1, 25),
                            Url = "https://www.youtube.com/embeded"
                        }
                    );
                }


                context.SaveChanges();
            }

        }
    }
}
