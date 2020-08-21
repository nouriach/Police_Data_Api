using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using policeDataApi_Practice.Data;
using policeDataApi_Practice.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace policeDataApi_Practice.Controllers
{
    public class FilterStreetCrimes : Controller
    {

        private readonly IStreetLevelCrimesRepo _crimesRepo;

        public FilterStreetCrimes(IStreetLevelCrimesRepo crimesRepo)
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
            var streetLevelResultsByDate = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndTime(model.Month, model.Year);

            if (streetLevelResultsByDate != null)
            {
                return Ok(streetLevelResultsByDate);
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
               new SelectListItem { Text = "May", Value ="05" }
            };

            getDates.Years = new List<SelectListItem>
            {
               new SelectListItem { Text = "2020", Value = "2020" },
               new SelectListItem { Text = "2019", Value = "2019" },
               new SelectListItem { Text = "2018", Value =  "2018" },
               new SelectListItem { Text = "2017", Value = "2017" }
            };

            return getDates;
        }
    }
}
