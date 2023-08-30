using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class AuteurController : ControllerBase
    {
        public AuteurController(DefaultContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            var mesAuteurs = _context.Auteurs.ToList();

            return View(mesAuteurs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auteur = _context.Auteurs.FirstOrDefault(bd => bd.AuteurId == id);
            if (auteur == null)
            {
                return NotFound();
            }

            return View(auteur);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                this._context.Auteurs.Add(auteur);
                this._context.SaveChanges();
                return View("Details", auteur);
            }

            return View();
        }
    }
}
