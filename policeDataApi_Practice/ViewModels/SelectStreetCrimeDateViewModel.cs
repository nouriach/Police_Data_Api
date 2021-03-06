﻿using Microsoft.AspNetCore.Mvc.Rendering;
using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeDataApi_Practice.Models.StreetLevelOutcomesModel;

namespace policeDataApi_Practice.ViewModels
{
    public class SelectStreetCrimeDateViewModel
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public Postcode Postcode { get; set; }
        public string PostcodePartOne { get; set; }
        public string PostcodePartTwo { get; set; }
        public List<string> FilteredCategories { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Months { get; set; }
        public StreetLevelCrimesModel[] Crimes { get; set; }
        public bool CrimesLoaded { get; set; }

    }
}
