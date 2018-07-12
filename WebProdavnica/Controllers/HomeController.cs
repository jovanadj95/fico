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
            int a = 0;
            if(kategorija.Equals("Graficke karte"))
            {
                a = 4;
            }
            ViewBag.Kategorija = kategorija;
        
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;
            IEnumerable<Kategorija> listaKategorija = db.Kategorije;
            if (kategorija != "")
            {
                listaProizvoda = listaProizvoda
                .Where(p => p.KategorijaId == a);
              
            }
            return View("Index", listaProizvoda.ToList());

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
