using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

using System;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.verificaLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            LivroService livroService = new LivroService();

            if(l.Id == 0)
            {
                livroService.Inserir(l);
            }
            else
            {
                livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, string itensPorPagina, int numPagina, int paginaAtual)
        {
            // check usuario logado
            Autenticacao.verificaLogin(this);
            FiltrosLivros objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }


// uso para paginação 
// Muda itensPorPagina para INT
     ViewData["livrosPorPagina"] = (string.IsNullOrEmpty(itensPorPagina) ? 10 : Int32.Parse(itensPorPagina)); 
    //Se a pagina for diferente de zero fica 1
            ViewData["paginaAtual"] = (paginaAtual!=0 ? paginaAtual : 1); 


            LivroService livroService = new LivroService();
            return View(livroService.ListarTodos(objFiltro));
            

        }


        public IActionResult Edicao(int id)
        {
            Autenticacao.verificaLogin(this);
            LivroService ls = new LivroService();
            Livro l = ls.ObterPorId(id);
            return View(l);
        }
    }
}