using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using policeDataApi_Practice.Data;
using policeDataApi_Practice.ViewModels;

namespace policeDataApi_Practice.Controllers
{
    public class YourNeighbourhoodController : Controller
    {
        private IYourNeighbourhoodRepo _neighbourhoodRepo;

        public YourNeighbourhoodController(IYourNeighbourhoodRepo neighbourhoodRepo)
        {
            _neighbourhoodRepo = neighbourhoodRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DisplayLocalNeighbourhoodViewModel model)
        {
            var neighbourhood = await _neighbourhoodRepo.GetNeighbourhoodLocation(model.PostcodeIncode, model.PostcodeOutcode);

            if (neighbourhood != null)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }
    }
}