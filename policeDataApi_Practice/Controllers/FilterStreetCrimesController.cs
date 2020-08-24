using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using policeDataApi_Practice.Data;
using policeDataApi_Practice.Models;
using policeDataApi_Practice.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace policeDataApi_Practice.Controllers
{
    public class FilterStreetCrimesController : Controller
    {

        private readonly IStreetLevelCrimesRepo _crimesRepo;
        private StreetLevelCrimesModel[] _streetLevelCrimes;

        public FilterStreetCrimesController(IStreetLevelCrimesRepo crimesRepo)
        {
            _crimesRepo = crimesRepo;
        }


        public IActionResult Index()
        {
            var filterCrimesViewModel = GetMonthsAndYears();

            return View(filterCrimesViewModel);
        }

       [HttpPost]
        public async Task<IActionResult> Index(SelectStreetCrimeDateViewModel model)
        {
            var streetLevelResultsByDate = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndTime(model.Month, model.Year, model.PostcodePartOne, model.PostcodePartTwo);

            if (streetLevelResultsByDate != null)
            {
                return View(streetLevelResultsByDate);
            }

            return NotFound();
        }

        private SelectStreetCrimeDateViewModel GetMonthsAndYears()
        {
            var getDates = new SelectStreetCrimeDateViewModel();

            getDates.Months = new List<SelectListItem>
            {
               new SelectListItem { Text = "January", Value = "01" },
               new SelectListItem { Text = "February", Value = "02" },
               new SelectListItem { Text = "March", Value =  "03" },
               new SelectListItem { Text = "April", Value = "04" },
               new SelectListItem { Text = "May", Value ="05" },
               new SelectListItem { Text = "June", Value = "06" },
               new SelectListItem { Text = "July", Value = "07" },
               new SelectListItem { Text = "August", Value =  "08" },
               new SelectListItem { Text = "September", Value = "09" },
               new SelectListItem { Text = "October", Value ="10" },
               new SelectListItem { Text = "November", Value =  "11" },
               new SelectListItem { Text = "December", Value = "12" },
            };

            getDates.Years = new List<SelectListItem>
            {
               new SelectListItem { Text = "2020", Value = "2020" },
               new SelectListItem { Text = "2019", Value = "2019" },
               new SelectListItem { Text = "2018", Value =  "2018" },
               new SelectListItem { Text = "2017", Value = "2017" },
               new SelectListItem { Text = "2016", Value = "2016" },
               new SelectListItem { Text = "2015", Value = "2015" },
               new SelectListItem { Text = "2014", Value =  "2014" },
               new SelectListItem { Text = "2013", Value = "2013" }
            };

            getDates.CrimesLoaded = false;

            return getDates;
        }
    }
}
