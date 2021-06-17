using Locadora.Controllers;
using Locadora.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Data
{
    public class LocadoraContext : IdentityDbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) //Contexto do projeto
        {
        }
        public DbSet<Filme> Filme { get; set;}
        public DbSet<Aluguel> Aluguel {get; set;}
    }
}
