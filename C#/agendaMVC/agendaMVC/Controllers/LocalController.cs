using Microsoft.AspNetCore.Mvc;
using agendaMVC.Models;
using agendaMVC.Dao;

namespace agendaMVC.Controllers
{
    public class LocalController : Controller
    {
        static DaoLocal daoLocal = new DaoLocal();
        static DetalheLocal daoDetalheLocal = new DetalheLocal();

        static List<Local> local = Dados.Db.local;
        static Local itemLocal = null;

        public IActionResult Index()
        {
            daoLocal.mostrar(local);

            return View(local);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Local localObj)
        {
            daoLocal.criar(localObj);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            foreach (var item in local)
            {
                if(item.Id == id)
                {
                    itemLocal = item;
                }
            }

            return View(itemLocal);
        }

        [HttpPost]
        public IActionResult Edit(Local localObj)
        {
            daoLocal.att(localObj);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            foreach (var item in local)
            {
                if (item.Id == id)
                {
                    itemLocal = item;
                }
            }
            return View(itemLocal);
        }

        [HttpPost]
        public IActionResult Delete(Local localObj) 
        {
            daoLocal.deletar(localObj);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            foreach (var item in local)
            {
                if (item.Id == id)
                {
                    itemLocal = item;
                }
            }

            daoDetalheLocal.detalhe(itemLocal, local);

            return View(itemLocal);
        }
    }
}
