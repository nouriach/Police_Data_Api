using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using policeDataApi_Practice.Data;

namespace policeDataApi_Practice.Controllers
{
    [Route("api/streetcrime")]
    [ApiController]
    public class StreetCrimesController : Controller
    {
        private readonly IStreetLevelCrimesRepo _crimesRepo;
        private readonly IStreetLevelOutcomesRepo _crimesOutcomesRepo;
        private readonly IMapper _mapper;

        public StreetCrimesController(IStreetLevelCrimesRepo crimesRepo, IStreetLevelOutcomesRepo crimesOutcomesRepo, IMapper mapper)
        {
            _crimesRepo = crimesRepo;
            _crimesOutcomesRepo = crimesOutcomesRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}