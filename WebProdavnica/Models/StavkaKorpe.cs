﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProdavnica.Models;

namespace WebProdavnica.Models
{
    public class StavkaKorpe
    {
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
    }
}
