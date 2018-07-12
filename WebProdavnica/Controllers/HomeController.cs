using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProdavnica.Models;

namespace WebProdavnica.Controllers
{
    public class HomeController : Controller
    {

        private readonly WebProdavnicaContext db;

        public HomeController(WebProdavnicaContext _db)
        {
            db = _db;
        }
        public IActionResult Index(String kategorija="")
        {
            ViewBag.Kategorija = kategorija;
        
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;
            if (kategorija != "")
            {
                listaProizvoda = listaProizvoda
                .Where(p => p.KategorijaId == getNaziv(kategorija));
              
            }
            return View("Index", listaProizvoda.ToList());

        }

        private int getNaziv(string kategorija)
        {
            IEnumerable<Kategorija> listaKategorija = db.Kategorije;
            listaKategorija=listaKategorija.Where(k => k.Naziv.Equals(kategorija));
            return listaKategorija.ElementAt(0).KategorijaId;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
