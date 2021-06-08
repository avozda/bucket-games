using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace bucket_games.Controllers
{
    public class Testuju : Controller
    {
        private double váhaNěmcovyMámy = double.PositiveInfinity;

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Testuju/Prankos
        // Requires using System.Text.Encodings.Web;
        public IActionResult Prankos(int kolik)
        {
            string prank = "";
            for (int i = 0; i < kolik; i++)
            {
                prank += $"Váha němcovy mámy je: {váhaNěmcovyMámy} \n";
            }
            //ViewData["Prank"] = HtmlEncoder.Default.Encode(prank);
            //^takhle se to má dělat abys nedostal hacki, ale pak nejde diakritika :c
            ViewData["Prank"] = prank;
            ViewData["KolikPranku"] = kolik;
            return View();
        }
    }
}
