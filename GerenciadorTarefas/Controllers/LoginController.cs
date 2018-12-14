using GerenciadorTarefas.Models.DAO;
using GerenciadorTarefas.Models.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorTarefas.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            Login login = new Login
            {
                Email = "admin",
                Senha = "admin"
            };
            return View(login);
        }
        
        public ActionResult ValidarLogin(String Email, String Senha)
        {
            LoginDAO loginDAO = new LoginDAO();

            if (loginDAO.IsLoginValido(Email, Senha))
            {
                Session["Login"] = new UsuarioDAO().GetByEmailSenha(Email, Senha);
                return Redirect("~/Usuario");
            }

            return Redirect("~/Login");                               
        }

        public ActionResult Sair()
        {
            Session.Remove("Login");
            return Redirect("~/Login");

        }

    }
}