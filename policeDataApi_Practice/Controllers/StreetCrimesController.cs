using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using policeDataApi_Practice.Data;
using policeDataApi_Practice.Dtos;
using policeDataApi_Practice.Models;

namespace policeDataApi_Practice.Controllers
{
    [Route("api/streetcrime")]
    [ApiController]
    public class StreetCrimesController : Controller
    {
        private readonly IStreetLevelCrimesRepo _crimesRepo;
        private readonly IStreetLevelOutcomesRepo _crimesOutcomesRepo;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public StreetCrimesController(IStreetLevelCrimesRepo crimesRepo, IStreetLevelOutcomesRepo crimesOutcomesRepo, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _crimesRepo = crimesRepo;
            _crimesOutcomesRepo = crimesOutcomesRepo;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        // -- GET api/streetcrime
        [HttpGet]
        public async Task<ActionResult> GetAllStreetCrimes()
        {
            var streetLevelResults = await _crimesRepo.GetAllStreetLevelCrimesByLocation();

            if (streetLevelResults != null)
            {
                // var test = _mapper.Map<IEnumerable<StreetLevelCrimesReadDto[]>>(streetLevelResults);

                return Ok(streetLevelResults);
            }
            return NotFound();
        }

    }
}