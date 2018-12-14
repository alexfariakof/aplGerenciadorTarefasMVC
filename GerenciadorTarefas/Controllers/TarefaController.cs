using System.Collections.Generic;
using System.Web.Mvc;
using GerenciadorTarefas.Models.POCO;
using GerenciadorTarefas.Models.DAO;

namespace GerenciadorTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly IEnumerable<Tarefa> listaTarefas;

        public TarefaController()
        {
            listaTarefas = new TarefaDAO().All;
        }

        public ActionResult Index()
        {
            return View(listaTarefas);
        }
        
        public ActionResult Tarefa()
        {
            ViewBag.Message = "Cadastro de Tarefas.";

            return View();
        }

        public ActionResult GetTarefaById(int id)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalvarTarefa(Tarefa tarefa)
        {
            Tarefa t = tarefa;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AtualizarTarefa(Tarefa tarefa)
        {
            Tarefa t = tarefa;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcluirTarefa(int id)
        {
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}