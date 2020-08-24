using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace policeDataApi_Practice.Controllers
{
    public class YourNeighbourhoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}