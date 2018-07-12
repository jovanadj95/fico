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
        public IActionResult Index(string id="")
        {
            
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;
            if (id !="")
            {
                Kategorija k1 = db.Kategorije.Find(id);

                if (k1 != null) 
                {
                    ViewBag.Kategorija = k1.Naziv;
                    ViewBag.KategorijaID = k1.KategorijaId;
                    listaProizvoda = listaProizvoda.Where(p => p.KategorijaId == Int32.Parse(id));
                   
                }

                else
                {
                    ViewBag.Kategorija = "";
                    return View();
                }

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
