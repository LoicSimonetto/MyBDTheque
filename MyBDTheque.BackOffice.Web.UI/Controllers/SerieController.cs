using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class SerieController : ControllerBase
    {
        public SerieController(DefaultContext context) : base(context)
        {
            
        }

        public IActionResult Index()
        {
            var mesSeries = _context.Series.ToList();

            return View(mesSeries);
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
