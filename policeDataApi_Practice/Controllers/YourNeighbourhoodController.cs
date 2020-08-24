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
            return View();
        }
    }
}