using Locadora.Controllers;
using Locadora.Data;
using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Services
{
    public class FilmesService 
    { 
        private LocadoraContext _context;

        public FilmesService(LocadoraContext context)
        {
            _context = context;
        }
        public List<Filme> getAll()
        {
            return _context.Filme.ToList();
        }
    }
}