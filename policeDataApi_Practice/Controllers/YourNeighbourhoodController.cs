using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using policeDataApi_Practice.ViewModels;

namespace policeDataApi_Practice.Controllers
{
    public class YourNeighbourhoodController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DisplayLocalNeighbourhoodViewModel model)
        {



            /*
            var streetLevelResultsByDate = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndTime(model.PostcodePartOne, model.PostcodePartTwo);
            streetLevelResultsByDate.AllCategories = await _crimesRepo.GetAllCategories();
            if (streetLevelResultsByDate != null)
            {
                return View(streetLevelResultsByDate);
            }

            return NotFound();
            */
        }
    }
}