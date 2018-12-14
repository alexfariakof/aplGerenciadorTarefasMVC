using GerenciadorTarefas.Models.DAO;
using GerenciadorTarefas.Models.POCO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GerenciadorTarefas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IEnumerable<Usuario> listaUsuarios;

        public UsuarioController()
        {
            if ((Session != null) && (Session["Login"] != null))
                Redirect("~/Login/Index");

            listaUsuarios = new UsuarioDAO().All;
        }

        public ActionResult Index()
        {
           return View(listaUsuarios);
        }

        public ActionResult GetUsuarioById(int id)
        {
            Usuario usuario = new UsuarioDAO().GetById(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalvarUsuario(Usuario usuario)
        {
            IDAO<Usuario> dao = new UsuarioDAO();
            dao.Insert(usuario);
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AtualizarUsuario(Usuario usuario)
        {
            IDAO<Usuario> dao = new UsuarioDAO();
            dao.Update(usuario);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcluirUsuario(int id)
        {
            IDAO<Usuario> dao = new UsuarioDAO();
            dao.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }


    }
}