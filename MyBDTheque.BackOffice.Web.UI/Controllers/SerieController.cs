using LibrairiesAspnet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class SerieController : ControllerBase
    {
        public SerieController(DefaultContext context, IConfiguration configuration) : base(context,configuration)
        {
            
        }

        public async Task<IActionResult> Index(string? typeTrie,string? colonne, string? searchString, string currentFilter, int? pageNumber, bool? SuivantOuPrecedent)
        {
            if (SuivantOuPrecedent == null | SuivantOuPrecedent == false)
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

            System.Linq.IQueryable<Serie> mesSeries = _context.Series;

            if (!String.IsNullOrEmpty(searchString))
            {
                mesSeries = mesSeries.Where(s => s.Titre.Contains(searchString));
            }

            switch (typeTrie)
            {
                case "titre_asc":
                    mesSeries = mesSeries.OrderBy(s => s.Titre);
                    break;
                case "titre_desc":
                    mesSeries = mesSeries.OrderByDescending(s => s.Titre);
                    break;
                default:
                    break;
            }

            int pageSize;
            if (!int.TryParse(this._configuration["NbElementParPage"], out pageSize))
            {
                pageSize = 6;
            }

            return View(await PaginatedList<Serie>.CreateAsync(mesSeries.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = _context.Series.FirstOrDefault(bd => bd.SerieId == id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Serie serie)
        {
            if (ModelState.IsValid)
            {
                this._context.Series.Add(serie);
                this._context.SaveChanges();
                return View("Details",serie);
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            Serie? serie = null;
            serie = this._context.Series.FirstOrDefault(s => s.SerieId== id);

            if (serie != null) 
            {
                ViewBag.BandeDessineesLibres = _context.BandeDessinees.Include(bd => bd.Serie).Where(bd => bd.SerieId == null).ToList();

                ViewBag.SesBandeDessinees = _context.BandeDessinees.Include(bd => bd.Serie).Where(bd => bd.SerieId == id).ToList();

                return View(serie);
            }

            return RedirectToAction("Index", _context.Series.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Serie serie, string[] sesBandeDessinees, string[] newBandeDessinees) // , string[] bandeDessinees, bool CheckModifier
        {
            if (ModelState.IsValid) 
            {
                if (sesBandeDessinees.Length > 0) 
                {
                    foreach (var id in sesBandeDessinees)
                    {
                        var bd = _context.BandeDessinees.First(bd => bd.BandeDessineeId == int.Parse(id));
                        bd.SerieId = null;
                        _context.BandeDessinees.Update(bd);
                    }
                }

                if (newBandeDessinees.Length > 0)
                {
                    foreach (var id in newBandeDessinees)
                    {
                        var bd = _context.BandeDessinees.First(bd => bd.BandeDessineeId == int.Parse(id));
                        bd.SerieId = serie.SerieId;
                        _context.BandeDessinees.Update(bd);
                    }
                }

                _context.Series.Update(serie);
                _context.SaveChanges();

                return View("Index", _context.Series.ToList());
            }

            ViewBag.BandeDessineesLibres = _context.BandeDessinees.Include(bd => bd.Serie).Where(bd => bd.SerieId == null).ToList();

            ViewBag.SesBandeDessinees = _context.BandeDessinees.Include(bd => bd.Serie).Where(bd => bd.SerieId == serie.SerieId).ToList();

            return View(serie);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = _context.Series.FirstOrDefault(s => s.SerieId == id);

            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirmed(int id, bool tout)
        {
            Serie? serie = _context.Series.Find(id);

            if (serie != null)
            {
                var bds = _context.BandeDessinees.Where(bd => bd.SerieId == id).ToList();

                if (bds.Count > 0)
                {
                    foreach (var bd in bds)
                    {
                        if (tout == false) // On supprime que le lien vers les bds
                        {
                            bd.SerieId = null;
                            _context.BandeDessinees.Update(bd);
                        }
                        else // on supprime la bd (+ supp liens avec les auteurs)
                        {
                            foreach (var bda in _context.BandeDessineeAuteurs)
                            {
                                if (bda.BandeDessineeId == bd.BandeDessineeId)
                                {
                                    _context.BandeDessineeAuteurs.Remove(bda);
                                }
                            }
                        }
                    }    
                } 

                _context.Series.Remove(serie);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ListeBandeDessineesFiltree(string id)
        {
            if (id == "0")
            {
                ViewBag.BandeDessinees = _context.BandeDessinees.Include(bd => bd.Serie).ToList();
            }
            else
            {
                ViewBag.BandeDessinees = _context.BandeDessinees.Include(bd => bd.Serie).Where(bd => bd.SerieId == null).ToList();
            }

            return PartialView("ListeBandeDessineesFiltree");
        }
    }
}
