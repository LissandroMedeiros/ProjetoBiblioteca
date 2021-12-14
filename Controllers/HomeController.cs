using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.verificaLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
        // PARAMETRO ORIGINAL 
        //    if(login != "admin" || senha != "123")
        //    {
        //        ViewData["Erro"] = "Senha inválida";
        //        return View();
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetString("user", "admin");
        //        return RedirectToAction("Index");
        //    } 

 //Se o login/senha OK
            if(Autenticacao.verificaLoginSenha(login, senha, this))
            { 
                //grava nos cookies
                HttpContext.Session.SetString("Login", login);
                
                //Redir inicial
                return RedirectToAction("Index");
            }
            else
            {
                //Exibe erro
                ViewData["Erro"] = "Login ou Senha inválidos";

                //Retorna a propria View
                return View();               
            }




        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
