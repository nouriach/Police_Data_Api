using AutoMapper;
using policeDataApi_Practice.Dtos;
using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Profiles
{
    public class ApiCallProfile : Profile
    {
        public ApiCallProfile()
        {
            CreateMap<StreetLevelCrimesModel, StreetLevelCrimesReadDto>();
            CreateMap<StreetLevelOutcomesModel, StreetLevelOutcomesReadDto>();
        }
    }
}
