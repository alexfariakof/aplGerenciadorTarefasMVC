using GerenciadorTarefas.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorTarefas.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Sair()
        {
            Login login = (Login)Session["Login"];
            Session["Login"] = new Login { Email = "Tesre", Senha = "admin", Id = "011" };
            login = (Login)Session["Login"];
            Session.Remove("Login");
            return Redirect("~/Login/Index");

        }


    }
}