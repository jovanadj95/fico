using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProdavnica.Models
{
    [Table("Kategorija")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Proizvodi = new HashSet<Proizvod>();
        }

        public int KategorijaId { get; set; }
        [StringLength(100)]
        public string Naziv { get; set; }

        [InverseProperty("Kategorija")]
        public ICollection<Proizvod> Proizvodi { get; set; }
    }
}
