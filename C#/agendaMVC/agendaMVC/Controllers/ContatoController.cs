using Microsoft.AspNetCore.Mvc;
using agendaMVC.Models;

namespace agendaMVC.Controllers
{
    public class ContatoController : Controller
    {
        static List<Contato> contatos = Dados.Db.contatos;

        static Dao.DaoContato daoContato = new Dao.DaoContato();
        static Dao.DetalheContato daoDetalheContato = new Dao.DetalheContato();

        static Contato contatoFora = null;
        public IActionResult Index()
        {
            daoContato.mostrar(contatos);

            return View(contatos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            daoContato.criar(contato);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            foreach (var contato in contatos)
            {
                if(contato.Id == id)
                { 
                    contatoFora = contato;
                    break;
                }
            }

            return View(contatoFora);
        }

        [HttpPost]      
        public IActionResult Edit(Contato contato)
        {
            daoContato.att(contato);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            foreach (var item in contatos)
            {
                if(id == item.Id)
                {
                    contatoFora = item;
                    break;
                }
            }

            return View(contatoFora);
        }

        [HttpPost]
        public IActionResult Delete()
        {
            daoContato.deletar(contatoFora);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            foreach (var item in contatos)
            {
                if (id == item.Id)
                {
                    contatoFora = item;
                }
            }

            daoDetalheContato.detalhe(contatoFora, contatos);

            return View(contatos);
        }
    }
}
