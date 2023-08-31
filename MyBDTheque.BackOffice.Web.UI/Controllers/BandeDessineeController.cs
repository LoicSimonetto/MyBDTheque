using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBDTheque.Core.Data;
using System.Linq;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class BandeDessineeController : ControllerBase
    {
        public BandeDessineeController(DefaultContext context) : base(context)
        {
        }

        public IActionResult Index(string? typeTrie, string? colonne, string? searchString)
        {
            if (colonne == "Titre")
            {
                if ((typeTrie != null && !typeTrie.Contains("titre")) | typeTrie == null | typeTrie == "titre_desc")
                {
                    typeTrie = "titre_asc";
                }
                else if (typeTrie == "titre_asc")
                {
                    typeTrie = "titre_desc";
                } 
            }
            else if (colonne == "DateParution")
            {
                if ((typeTrie != null && !typeTrie.Contains("date")) |  typeTrie == null | typeTrie == "date_desc")
                {
                    typeTrie = "date_asc";
                }
                else if (typeTrie == "date_asc")
                {
                    typeTrie = "date_desc";
                }
            }

            ViewBag.TypeTrie = typeTrie;

            List<BandeDessinee>? mesBds = _context.BandeDessinees.Include(bd => bd.Serie).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                mesBds = mesBds.Where(s => s.Titre.Contains(searchString)).ToList();
            }

            switch (typeTrie)
            {
                case "titre_asc":
                    mesBds = mesBds.OrderBy(bd => bd.Titre).ToList();
                    break;
                case "titre_desc":
                    mesBds = mesBds.OrderByDescending(bd => bd.Titre).ToList();
                    break;
                case "date_asc":
                    mesBds = mesBds.OrderBy(bd => bd.DateParution).ToList();
                    break;
                case "date_desc":
                    mesBds = mesBds.OrderByDescending(bd => bd.DateParution).ToList();
                    break;
                default:
                    break;
            }

            return View(mesBds);
        }

        public IActionResult Details(int? id) 
        { 
            if (id == null) 
            {
                return NotFound();
            }

            var bd = _context.BandeDessinees.Include(bd => bd.Serie)
                                            .Include(bda => bda.BandeDessineeAuteurs)
                                            .ThenInclude(a => a.Auteur)
                                            .FirstOrDefault(bd => bd.BandeDessineeId == id);
            if (bd == null)
            {
                return NotFound();
            }

            var LesAuteurs = new List<SelectListItem>();
            foreach (var item in bd.BandeDessineeAuteurs)
            {
                LesAuteurs.Add(new SelectListItem() { Text = _context.Auteurs.Single(a => a.AuteurId == item.AuteurId).NomComplet, Value = item.AuteurId.ToString()});
            }
            ViewBag.Auteurs = LesAuteurs;


            return View(bd);
        }

        public IActionResult Create()
        {
            // Passage de la liste des auteurs :
            ViewBag.LesAuteurs = _context.Auteurs.ToList();

            // Passage de la liste des séries :
            ViewBag.LesSeries = _context.Series.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BandeDessinee bandeDessinee, string[] auteurs) 
        {
            if (ModelState.IsValid) 
            {
                if (_context.Series.FirstOrDefault(s => s.SerieId == bandeDessinee.SerieId) == null) 
                {
                    bandeDessinee.SerieId = null;
                }

                _context.BandeDessinees.Add(bandeDessinee);
                _context.SaveChanges();

                foreach (var auteur in auteurs)
                {
                    BandeDessineeAuteur bandeDessineeAuteur = new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandeDessinee.BandeDessineeId,
                        AuteurId = int.Parse(auteur)
                    };
                    _context.BandeDessineeAuteurs.Add(bandeDessineeAuteur);
                }

                _context.SaveChanges();

                return View("Index", _context.BandeDessinees.Include(bd => bd.Serie).ToList());
            }

            // Passage de la liste des auteurs :
            ViewBag.LesAuteurs = _context.Auteurs.ToList();

            // Passage de la liste des séries :
            ViewBag.LesSeries = _context.Series.ToList();

            return View(bandeDessinee);
        }

        public IActionResult Edit(int id)
        {
            BandeDessinee? bandeDessinee = null;
            bandeDessinee = _context.BandeDessinees.Include(bd => bd.Serie)
                                            .Include(bda => bda.BandeDessineeAuteurs)
                                            .ThenInclude(a => a.Auteur)
                                            .FirstOrDefault(a => a.BandeDessineeId == id);

            if (bandeDessinee != null)
            {
                // Passage de la liste des auteurs :
                ViewBag.LesAuteurs = _context.Auteurs.ToList();
         
                // Passage de la liste des séries :
                ViewBag.LesSeries = _context.Series.ToList();

                return View(bandeDessinee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BandeDessinee bandeDessinee, string[] auteurs)
        {
            if (ModelState.IsValid)
            {
                if (_context.Series.FirstOrDefault(s => s.SerieId == bandeDessinee.SerieId) == null)
                {
                    bandeDessinee.SerieId = null;
                }

                _context.BandeDessinees.Update(bandeDessinee);
                _context.SaveChanges();

                // gestion des auteurs
                if (auteurs.Length == 0 | (auteurs.Length == 1 && auteurs[0] == "0"))
                {
                    // On supprime tous les auteurs
                    foreach (var item in _context.BandeDessineeAuteurs.Where(bda => bda.BandeDessineeId == bandeDessinee.BandeDessineeId).ToList()) 
                    {
                        _context.BandeDessineeAuteurs.Remove(item);
                    }
                }
                else
                {
                    List<string> lauteurs = auteurs.ToList();

                    // supprimer auteurs non "renouvellés"
                    foreach (var bda in _context.BandeDessineeAuteurs)
                    {
                        if (bda.BandeDessineeId == bandeDessinee.BandeDessineeId)
                        {
                            bool trouve = false;
                            foreach (var la in lauteurs)
                            {
                                if (bda.AuteurId == int.Parse(la))
                                {
                                    trouve = true;
                                    break;
                                }
                            }
                            if (!trouve) _context.BandeDessineeAuteurs.Remove(bda);
                        }
                    }

                    // Ajouter nouveaux auteurs
                    foreach (var auteurId in lauteurs)
                    {
                        if (_context.BandeDessineeAuteurs.ToList().Find(abd => abd.AuteurId == int.Parse(auteurId) && abd.BandeDessineeId == bandeDessinee.BandeDessineeId) == null)
                        {
                            _context.BandeDessineeAuteurs.Add(new BandeDessineeAuteur { AuteurId = int.Parse(auteurId), BandeDessineeId = bandeDessinee.BandeDessineeId });
                        }
                    }
                }

                _context.SaveChanges();
                
                return View("Index", _context.BandeDessinees.Include(bd => bd.Serie).ToList());
            }

            // Passage de la liste des auteurs :
            ViewBag.LesAuteurs = _context.Auteurs.ToList();

            // Passage de la liste des séries :
            ViewBag.LesSeries = _context.Series.ToList();

            return View(bandeDessinee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bd = _context.BandeDessinees.Include(bd => bd.Serie).FirstOrDefault(bd => bd.BandeDessineeId == id);

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
            BandeDessinee? bd = _context.BandeDessinees.Find(id);

            if (bd != null)
            {
                _context.BandeDessinees.Remove(bd);

                // Suppression des liens avec les auteurs
                foreach (var item in _context.BandeDessineeAuteurs)
                {
                    if (item.BandeDessineeId == id)
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
