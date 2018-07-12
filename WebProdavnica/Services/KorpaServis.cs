using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProdavnica.Extensions;
using WebProdavnica.Models;

namespace WebProdavnica.Services
{
    public class KorpaServis
    {
        private readonly IHttpContextAccessor accessor;

        public KorpaServis(IHttpContextAccessor _accessor)
        {         
            accessor = _accessor;        
        }

        public Korpa CitajKorpu()
        {
            Korpa korpa;
            ISession sesija = accessor.HttpContext.Session;
            if (sesija.DeserijalizujKorpu("Korpa") != null)
            {
                korpa = sesija.DeserijalizujKorpu("Korpa");
            }

            else
            {
                korpa = new Korpa();
            }
            return korpa;
        }

        public void CuvajKorpu(Korpa korpa)
        {
            accessor.HttpContext.Session.SerijalizujKorpu("Korpa", korpa);
        }


        public void ObrisiKorpu()
        {
            accessor.HttpContext.Session.Clear();
        }
    }
}
