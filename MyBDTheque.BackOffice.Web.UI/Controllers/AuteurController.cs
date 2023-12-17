using LibrairiesAspnet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class AuteurController : ControllerBase
    {
        public AuteurController(DefaultContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task<IActionResult> Index(string? typeTrie, string? colonne, string? searchString, string currentFilter, int? pageNumber, bool? SuivantOuPrecedent)
        {
            if (SuivantOuPrecedent == null | SuivantOuPrecedent == false)
            {
                if (colonne == "NomComplet")
                {
                    if ((typeTrie != null && !typeTrie.Contains("nomcomplet")) | typeTrie == null | typeTrie == "nomcomplet_desc")
                    {
                        typeTrie = "nomcomplet_asc";
                    }
                    else if (typeTrie == "nomcomplet_asc")
                    {
                        typeTrie = "nomcomplet_desc";
                    }
                }
                else if (colonne == "DateDeNaissance")
                {
                    if ((typeTrie != null && !typeTrie.Contains("datedenaissance")) | typeTrie == null | typeTrie == "datedenaissance_desc")
                    {
                        typeTrie = "datedenaissance_asc";
                    }
                    else if (typeTrie == "datedenaissance_asc")
                    {
                        typeTrie = "datedenaissance_desc";
                    }
                }
            }
            ViewBag.TypeTrie = typeTrie;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            System.Linq.IQueryable<Auteur> mesAuteurs = _context.Auteurs;

            if (!String.IsNullOrEmpty(searchString))
            {
                mesAuteurs = mesAuteurs.Where(s => s.NomComplet.Contains(searchString));
            }

            switch (typeTrie)
            {
                case "nomcomplet_asc":
                    mesAuteurs = mesAuteurs.OrderBy(bd => bd.Nom + " " + bd.Prenom);
                    break;
                case "nomcomplet_desc":
                    mesAuteurs = mesAuteurs.OrderByDescending(bd => bd.Nom + " " + bd.Prenom);
                    break;
                case "datedenaissance_asc":
                    mesAuteurs = mesAuteurs.OrderBy(bd => bd.DateDeNaissance);
                    break;
                case "datedenaissance_desc":
                    mesAuteurs = mesAuteurs.OrderByDescending(bd => bd.DateDeNaissance);
                    break;
                default:
                    break;
            }

            int pageSize;
            if (!int.TryParse(this._configuration["NbElementParPage"], out pageSize))
            {
                pageSize = 6;
            }
            return View(await PaginatedList<Auteur>.CreateAsync(mesAuteurs.AsNoTracking(), pageNumber ?? 1, pageSize));
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

        public IActionResult Edit(int id)
        {
            Auteur? auteur = null;
            auteur = _context.Auteurs.FirstOrDefault(a => a.AuteurId == id);

            if (auteur != null)
            {
                return View(auteur);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                _context.Auteurs.Update(auteur);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(auteur);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bd = _context.Auteurs.Include(bd => bd.BandeDessineeAuteurs).FirstOrDefault(bd => bd.AuteurId == id);

            if (bd == null)
            {
                return NotFound();
            }

            return View(bd);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Auteur? auteur = _context.Auteurs.Find(id);

            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);

                // Suppression des liens avec les bande dessinées
                foreach (var item in _context.BandeDessineeAuteurs)
                {
                    if (item.AuteurId == id)
                    {
                        _context.BandeDessineeAuteurs.Remove(item);
                    }
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
