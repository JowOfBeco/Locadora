using Locadora.Data;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Services
{   //Classe de serviço de conexão com nosso banco de dados via contexto
    //Aqui está nosso crud trabalhando com a persistencia
    public class AluguelSqlService : IAluguelService
    {
        private LocadoraContext _context;
        public AluguelSqlService(LocadoraContext context)
        {
            _context = context;
        }

        public bool Create(Aluguel c)
        {
            try {
                _context.Add(c);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                _context.Remove(Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Aluguel Get(int? id) => _context.Aluguel.Include(a => a.filme).FirstOrDefault(a => a.id == id);

        public List<Aluguel> getAll(string busca = null) => 
            _context.Aluguel.Include(a => a.filme).ToList();

        public bool Update(Aluguel c)
        {
            try { 
                _context.Update(c);
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
