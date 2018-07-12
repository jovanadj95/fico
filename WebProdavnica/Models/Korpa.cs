using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProdavnica.Models;

namespace WebProdavnica.Models
{
    public class Korpa
    {
        private List<StavkaKorpe> kolekcijaStavki = new List<StavkaKorpe>();

        public virtual void DodajStavku(Proizvod proizvod, int kolicina)
        {
            StavkaKorpe st = kolekcijaStavki
                .SingleOrDefault(p => p.Proizvod.ProizvodId == proizvod.ProizvodId);
               

            if (st == null)
            {
                st = new StavkaKorpe {
                    Proizvod = proizvod,
                    Kolicina = kolicina
                };
                kolekcijaStavki.Add(st);
            }
            else
            {
                st.Kolicina += kolicina;
            }
        }

        public virtual void ObrisiStavku(Proizvod proizvod)
        {
            StavkaKorpe st1 = kolekcijaStavki.SingleOrDefault(st => st.Proizvod.ProizvodId == proizvod.ProizvodId);
            kolekcijaStavki.Remove(st1);
        }
       

        public virtual void PromeniStavku(Proizvod proizvod, int kolicina)
        {
            StavkaKorpe st = kolekcijaStavki.SingleOrDefault(s => s.Proizvod.ProizvodId == proizvod.ProizvodId);

            if (st != null)
            {
                st.Kolicina = kolicina;
            }
        }
        public virtual decimal VrednostKorpe()
        {
           decimal vrednost= kolekcijaStavki.Sum(p => p.Proizvod.Cena * p.Kolicina);
            return vrednost;
        }
      

        public virtual void ObrisiKorpu()
        {
            kolekcijaStavki.Clear();
        }

        public IEnumerable<StavkaKorpe> Stavke
        {
            get
            {
                return kolekcijaStavki;
            }
        }
    }
}
