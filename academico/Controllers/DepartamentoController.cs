using academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                DepartamentoID = 1,
                Nome = "Recursos Humanos",

            },
            new Departamento()
            {
                DepartamentoID = 2,
                Nome = "Financeiro",
            },
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            departamento.DepartamentoID = departamentos.Select(i => i.DepartamentoID).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoID == departamento.DepartamentoID).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Departamento departamento)
        {
            departamentos.Remove(departamentos.First(i => i.DepartamentoID == departamento.DepartamentoID));

            return RedirectToAction("index");
        }
    }
}
