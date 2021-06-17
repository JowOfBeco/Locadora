using Locadora.Models;
using System.Collections.Generic;

namespace Locadora.Controllers
{
    public interface IFilmesService
    {//interface com regra de metodos a serem utilizados no nosso crud
        List<Filme> getAll(string busca = null);
        Filme Get(int? id);
        bool Update(Filme p);
        bool Delete(int? id);
        bool Create(Filme p);

    }
}