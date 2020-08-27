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
            var viewModel = new DisplayLocalNeighbourhoodViewModel
            {
                NeighbourhoodLoaded = false
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DisplayLocalNeighbourhoodViewModel model)
        {
            var neighbourhood = await _neighbourhoodRepo.GetNeighbourhoodLocation(model.PostcodeIncode, model.PostcodeOutcode);

            neighbourhood.NeighbourhoodTeam = await _neighbourhoodRepo.GetNeighbourhoodTeam(
                neighbourhood.LocateNeighbourhood.force, 
                neighbourhood.LocateNeighbourhood.neighbourhood);

            neighbourhood.NeighbourhoodDetails = await _neighbourhoodRepo.GetNeighbourhoodDetails(
                neighbourhood.LocateNeighbourhood.force,
                neighbourhood.LocateNeighbourhood.neighbourhood);

            if (neighbourhood != null)
            {
                return View(neighbourhood);
            }
            else
            {
                return NotFound();
            }
        }
    }
}