using AgenciaViagemMVCCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaViagemMVCCsharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pessoa()
        {
            ViewBag.Title = "Pessoas";
            ViewBag.Message = "Relação de pessoas";

            var lista = Pessoas.GetDados();
            ViewBag.Lista = lista;

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Entre em Contato";

            return View();
        }

        public ActionResult Promocoes()
        {
            return View();
        }
    }
}