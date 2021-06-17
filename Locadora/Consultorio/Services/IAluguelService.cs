using Locadora.Models;
using System.Collections.Generic;

namespace Locadora.Services
{
    public interface IAluguelService
    {//interface com regra de metodos a serem utilizados no nosso crud
        List<Aluguel> getAll(string busca = null);

        Aluguel Get(int? id);

        bool Update(Aluguel p);

        bool Delete(int? id);

        bool Create(Aluguel p);
    }
}