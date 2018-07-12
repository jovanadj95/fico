using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProdavnica.Models;

namespace WebProdavnica.Models
{
    [Table("Stavka")]
    public partial class Stavka
    {
        public int StavkaId { get; set; }
        public int PorudzbinaId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey("PorudzbinaId")]
        [InverseProperty("Stavke")]
        public Porudzbina Porudzbina { get; set; }


        [ForeignKey("ProizvodId")]
        [InverseProperty("Stavke")]
        public Proizvod Proizvod { get; set; }
    }
}
