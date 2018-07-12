using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProdavnica.Models
{ 
    [Table("Proizvod")]
    public partial class Proizvod
    {
        public Proizvod()
        {
            Stavke = new HashSet<Stavka>();
        }

        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
        [StringLength(100)]
        public string Naziv { get; set; }
        [StringLength(100)]
        public string Opis { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cena { get; set; }

        [ForeignKey("KategorijaId")]
        [InverseProperty("Proizvodi")]
        public Kategorija Kategorija { get; set; }
        [InverseProperty("Proizvod")]
        public ICollection<Stavka> Stavke { get; set; }
    }
}
