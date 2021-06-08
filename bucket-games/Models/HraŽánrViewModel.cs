using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bucket_games.Models
{
    public class HraŽánrViewModel
    {
        public List<Hra> Hry { get; set; }
        public SelectList Žánry { get; set; }
        public string HerníŽánr { get; set; }
        public string Vyhledávání { get; set; }
    }
}
