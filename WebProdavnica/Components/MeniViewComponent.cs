using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProdavnica.Models;

namespace WebProdavnica.Components
{
    public class MeniViewComponent :ViewComponent
    {
        private readonly WebProdavnicaContext db;
        public MeniViewComponent(WebProdavnicaContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<string> kategorija = db.Kategorije
             .Select(k => k.Naziv).Distinct()
            .OrderBy(k => k);
            return View(kategorija);
        }
    }
}
