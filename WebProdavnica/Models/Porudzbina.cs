using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProdavnica.Models
{   
    [Table("Porudzbina")]
    public partial class Porudzbina
    {
        public Porudzbina()
        {
            Stavke = new HashSet<Stavka>();
        }

        public int PorudzbinaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DatumKupovine { get; set; }

        [InverseProperty("Porudzbina")]
        public ICollection<Stavka> Stavke { get; set; }
    }
}
