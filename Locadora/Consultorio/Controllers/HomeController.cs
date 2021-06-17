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
    public class HomeController : Controller
    {
        private IFilmesService _service;

        public HomeController(IFilmesService service)
        {//Implementando interface de serviços do filme
            _service = service;
        }

        public IActionResult Index(string busca = null)
        {//Tela inicial de index, passando todos os filmes pelo metodo getAll
            return View(_service.getAll(busca));
        }

        [Authorize]
        public IActionResult Create() => View();
        //Tela de create "vazia"

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Filme filme)
        {//tela de create recebendo valores para preencher o objeto e cadastrar como filmes no bd
            if (!ModelState.IsValid) return View(filme);
            ViewBag.message = $"Filme {filme.Titulo} criado com sucesso!";
            return _service.Create(filme) ?
                RedirectToAction("Index") :
                NotFound();

        }

        public IActionResult Locadora() => View(); //Pagina "de boas vindas"

        public IActionResult Privacy() => View(); //Action de redirecionamento, igual o de cima
        public IActionResult Visualizar(int? id) //Action de visualizar recebendo um filme pela id, caso seja null retorna 400
        {
            Filme filme = _service.Get(id);
            return filme == null ? NotFound() : View(filme);
        }

        public IActionResult Sortear() //Metodo de sortear, na verdade é "ordenar", não sei pq coloquei esse nome
        {

            var filmes = _service.getAll();
            filmes.Sort(delegate (Filme p1, Filme p2)
        {
            return p1.Titulo.CompareTo(p2.Titulo);
        });
            return View("Index", filmes);
        }

        [Authorize]
        public IActionResult Atualizar(int? id)
        {
            Filme filme = _service.Get(id);
            return filme == null ? NotFound() : View(filme);

        }

        [Authorize]
        [HttpPost]
        public IActionResult Atualizar(Filme filme)//Action atualizar recebendo uma um filme do qual será passado via metodo serviço para alteração do filme
        {
            if (!ModelState.IsValid) return View(filme);
            ViewBag.message = $"Filme {filme.Titulo} atualizado com sucesso!";
            return _service.Update(filme) ?
                RedirectToAction("Index") :
                NotFound();
        }

        [Authorize]
        public IActionResult Deletar(int? id) //Delete por id
        {
            ViewBag.message = $"Filme deletado com sucesso!";
            return _service.Delete(id) ?
        RedirectToAction("Index") :
        NotFound();
        }
        public IActionResult ConfirmaDelete(int id) //Action da página de confirmação de delete do desafio

        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult Assitir(int id) //Essa action é para a página de assistir, pegando a url do filme especifico
        {
            var url = _service.Get(id);
            ViewBag.Url =  url.Url;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
