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
        // private readonly IMapper _mapper;

        public StreetCrimesController(IStreetLevelCrimesRepo crimesRepo, IStreetLevelOutcomesRepo crimesOutcomesRepo)
        {
            _crimesRepo = crimesRepo;
            _crimesOutcomesRepo = crimesOutcomesRepo;
            // _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        // -- GET api/streetcrime
        [HttpGet]
        public async Task <ActionResult<StreetLevelCrimesModel[]>> GetAllStreetCrimes()
        {
            var streetLevelResults = await _crimesRepo.GetAllStreetLevelCrimesByLocation();

            if (streetLevelResults != null)
            {
                return Ok(streetLevelResults);
            }
            return NotFound();
        }

        // -- GET api/streetcrime/GetStreetCrimeById/{id}
        [HttpGet]
        [Route("GetStreetCrimeById/{id}")]
        public async Task<ActionResult<StreetLevelCrimesModel>> GetStreetCrimeById(int id)
        {
            // PLACEHOLDER ID: 84551281, this works in Postman
            var streetLevelResult = await _crimesRepo.GetStreetLevelCrimeById(id);

            if (streetLevelResult != null)
            {
                return Ok(streetLevelResult);
            }

            return NotFound();
        }

        // GET api/streetcrime/GetStreetCrimesByCategory/{category}
        [HttpGet]
        [Route("GetStreetCrimesByCategory/{category}")]

        public async Task<ActionResult<StreetLevelCrimesModel[]>> GetStreetCrimesByCategory(string category)
        {
            // PLACEHOLDER CATEGORY 'burglary', works in Postman
            var streetLevelResultsByCategory = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndCategory(category);

            if (streetLevelResultsByCategory != null)
            {
                return Ok(streetLevelResultsByCategory);
            }

            return NotFound();
        }

        // GET api/streetcrime/GetStreetCrimesByCategory/{category}
        [HttpGet]
        [Route("GetStreetCrimeByLocationAndDate/{date}")]
        public async Task <ActionResult<StreetLevelCrimesModel[]>> GetStreetCrimeByLocationAndDate(string date)
        {
            // PLACEHOLDER DATE needs to be YYYY-MM, '2019-01' works in Postman
            var streetLevelResultsByDate = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndTime(date);

            if (streetLevelResultsByDate != null)
            {
                return Ok(streetLevelResultsByDate);
            }

            return NotFound();
        }

        // GET api/streetcrime/GetStreetCrimesByLocationAndCategoryAndTime/{category}/{date}
        [HttpGet]
        [Route("GetStreetCrimesByLocationAndCategoryAndTime/{category}/{date}")]
        public async Task<ActionResult<StreetLevelCrimesModel>> GetStreetCrimesByLocationAndCategoryAndTime(string category, string date)
        {
            // PLACEHOLDER DATE needs to be YYYY-MM, '2019-01' & burglary works in Postman
            var streetLevelResultByDateAndCategory = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndCategoryAndTime(category, date);

            if (streetLevelResultByDateAndCategory != null)
            {
                return Ok(streetLevelResultByDateAndCategory);
            }

            return NotFound();
        }


    }
}