using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace policeDataApi_Practice.Controllers
{
    public class StreetCrimesOutcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StreetCrimeOutcome(int crimeId, string date, string latitude, string longitude)
        {
            ViewBag.CrimeId = crimeId;
            return View();
        }
    }
}