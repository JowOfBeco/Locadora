using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
    [Authorize]
    public class AluguelController : Controller
    {
        private IAluguelService _service;
        private IFilmesService _fservice;

        public AluguelController(IAluguelService service, IFilmesService fservice)
        {
            _service = service;
            _fservice = fservice;
        }

        public IActionResult Index(string busca = null) =>
            View(_service.getAll(busca).Where(x => x.devolucao > x.dataHora).ToList());
        //Isso aqui foi um trunfo !! Obrigado por isso Hahaha.
        //Por enquanto vou deixar aqui, depois refatoro para o service.
   

        public IActionResult Create()
        {
            //view tela inicial do create
            var filmes = _fservice.getAll();
            ViewBag.listaDeFilmes = new SelectList(filmes, "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluguel aluguel)
        {
            //View recebendo daados para preenchimento do aluguel
            if (!ModelState.IsValid)
            {
                var filmes = _fservice.getAll();
                ViewBag.listaDeFilmes = new SelectList(filmes, "Id", "Titulo");
                ViewBag.message = $"Aluguel do filme {aluguel.filme.Titulo} criado com sucesso!";
                return View(aluguel);
            }
            //TODO: refatorar essa parte do código
            aluguel.devolucao = DateTime.Now.AddDays(aluguel.devolucaoDias);
            aluguel.dataHora = DateTime.Now;
            //Utilizei 3 variaveis, deixei um TODO ali pra rever isso.

            return _service.Create(aluguel) ?
                RedirectToAction("Index") :
                NotFound();
        }
        public IActionResult Visualizar(int? id)
        {//Visualiza e assiste o filme pela id passada
            Aluguel aluguel = _service.Get(id);
            return aluguel == null ? NotFound() : View(aluguel);
        }
        //Eu fiz todo o crude, achei até bom ter feito, foi bacana para os testes.
        public IActionResult Atualizar(int? id)
        {

            Aluguel aluguel = _service.Get(id);
            var filmes = _fservice.getAll();
            ViewBag.listaDeFilmes = new SelectList(filmes, "Id", "Titulo");
            return aluguel == null ? NotFound() : View(aluguel);
        }

        [HttpPost]
        public IActionResult Atualizar(Aluguel aluguel)
        {
            var filmes = _fservice.getAll();
            ViewBag.listaDeFilmes = new SelectList(filmes, "Id", "Titulo");
            ViewBag.message = $"Aluguel do filme {aluguel.filme.Titulo} atualizado com sucesso!";
            if (!ModelState.IsValid) return View(aluguel);
            return _service.Update(aluguel) ?
                RedirectToAction("Index") :
                NotFound();
        }
        public IActionResult Deletar(int? id) =>
            _service.Delete(id) ?
        RedirectToAction("Index") :
        NotFound();


        public IActionResult ConfirmaDelete(int id)
        //Como fiz todo o crude, achei bacana colocar a confirmação de delete aqui também
        {
            ViewBag.id = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
