using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using policeDataApi_Practice.Data;

namespace policeDataApi_Practice.Controllers
{
    public class StreetCrimesOutcomeController : Controller
    {
        private IStreetLevelOutcomesRepo _streetLevelCrimeOutcomes;

        public StreetCrimesOutcomeController(IStreetLevelOutcomesRepo streetLevelCrimeOutcomes)
        {
            _streetLevelCrimeOutcomes = streetLevelCrimeOutcomes;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> StreetCrimeOutcome(int crimeId, string date, string latitude, string longitude)
        {
            var streetLevelCrimeOutcome = await _streetLevelCrimeOutcomes.GetAllStreetLevelOutcomesByLocationAndTime(crimeId, date, latitude, longitude);

            if (streetLevelCrimeOutcome.StreetLevelCrimeOutcome != null)
            {

                return View(streetLevelCrimeOutcome);
            }
            else
            {
                streetLevelCrimeOutcome.CrimeOutcomeLoaded = false;
                return View(streetLevelCrimeOutcome);
            }
        }
    }
}