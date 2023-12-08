using agendaMVC.Dados;
using agendaMVC.Dao;
using agendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace agendaMVC.Controllers
{
    public class CompromissoController : Controller
    {
        static DaoCompromisso daoCompromisso = new DaoCompromisso();
        static DaoContato daoContato = new DaoContato();
        static DaoLocal daoLocal = new DaoLocal();
        static DetalheCompromisso daoDetalheCompromisso = new DetalheCompromisso();


        static List<Compromisso> compromisso = Db.compromisso;
        static List<Local> local = Db.local;
        static List<Contato> contato = Db.contatos;

        static Compromisso foraCompromisso = null;

        public IActionResult Index()
        {
            daoCompromisso.mostrar(compromisso);

            return View(compromisso);
        }

        [HttpGet]
        public IActionResult Create()
        {
            daoContato.mostrar(contato);
            daoLocal.mostrar(local);

            List<SelectListItem> Contatos = new List<SelectListItem>();
            List<SelectListItem> Local = new List<SelectListItem>();

            Contatos = contato.Select(c => new SelectListItem()
            { Text = c.Email, Value = c.Id.ToString()}).ToList();

            Local = local.Select(local => new SelectListItem() 
            { Text = local.Rua, Value = local.Id.ToString()}).ToList();

            ViewBag.Contatos = Contatos;
            ViewBag.Local = Local;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Compromisso compromissoEnviado)
        {
            daoCompromisso.criar(compromissoEnviado);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            foreach(Compromisso itemCompromisso in compromisso)
            {
                if(itemCompromisso.Id == id)
                {
                    foraCompromisso = itemCompromisso;
                    break;
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            daoCompromisso.deletar(foraCompromisso);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            daoContato.mostrar(contato);
            daoLocal.mostrar(local);

            List<SelectListItem> Contatos = new List<SelectListItem>();
            List<SelectListItem> Local = new List<SelectListItem>();

            Contatos = contato.Select(c => new SelectListItem()
            { Text = c.Email, Value = c.Id.ToString() }).ToList();

            Local = local.Select(local => new SelectListItem()
            { Text = local.Rua, Value = local.Id.ToString() }).ToList();

            ViewBag.Contatos = Contatos;
            ViewBag.Local = Local;


            foreach (var item in compromisso)
            {
                if (item.Id == id)
                {
                    foraCompromisso = item;
                }
            }

            return View(foraCompromisso);
        }

        [HttpPost]
        public IActionResult Edit(Compromisso editCompromisso)
        {
            daoCompromisso.att(editCompromisso);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            foreach (var item in compromisso)
            {
                if (item.Id == id)
                {
                    foraCompromisso = item;
                }
            }

            daoDetalheCompromisso.detalhe(foraCompromisso, compromisso);

            return View(compromisso);
        }
    }
}
