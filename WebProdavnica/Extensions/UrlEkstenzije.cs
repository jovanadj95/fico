﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProdavnica.Extensions;

namespace WebProdavnica.Extensions
{
    public static class UrlEkstenzije
    {
        public static string PutanjaQueryString(this HttpRequest zahtev)
        {
            if (zahtev.QueryString.HasValue)
            {
                return $"{zahtev.Path}{zahtev.QueryString}";
            }
            else
            {
                return zahtev.Path.ToString();
            }
        }
    }
}

