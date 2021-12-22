using AgenciaViagemMVCCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaViagemMVCCsharp.Controllers
{
    public class PessoasController : Controller
    {
        // GET: Pessoas
        public ActionResult Adicionar()
        {
            ViewBag.Title = "Pessoas";
            ViewBag.Message = "Adicionar Pessoa";

            return View();
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Title = "Pessoas";
            ViewBag.Message = "Alterar Dados";

            var pessoa = new Pessoas();
            pessoa.GetPessoas(id);
            return View(pessoa);
        }

        public ActionResult Excluir(int id)
        {
            ViewBag.Title = "Pessoas";
            ViewBag.Message = "Excluir Pessoa " + id;

            var pessoa = new Pessoas();
            pessoa.GetPessoas(id);
            ViewBag.Pessoa = pessoa;

            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Pessoas pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Salvar();
                return RedirectToAction("Pessoa", "Home");
            }
            else
            {
                ViewBag.Title = "Pessoas";
                if(Convert.ToInt32("0" + Request["id"]) == 0)
                {
                    ViewBag.Message = "Adicionar Pessoas";
                    return View("Adicionar");
                }
                else
                {
                    ViewBag.pessoa = pessoa;
                    ViewBag.Message = "Alterar Pessoa " + pessoa.Id;
                    return View("Alterar");
                }
            }
        }

        [HttpPost]
        public void Excluir()
        {
            var pessoa = new Pessoas();
            pessoa.Id = Convert.ToInt32("0" + Request["id"]);

            pessoa.Excluir();

            Response.Redirect("/Home/Pessoa");
        }
    }
}