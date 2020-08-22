using Microsoft.AspNetCore.Mvc.Rendering;
using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.ViewModels
{
    public class SelectStreetCrimeDateViewModel
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public Postcode Postcode { get; set; }
        public string PostcodePartOne { get; set; }
        public string PostcodePartTwo { get; set; }
        public List<string> Categories { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Months { get; set; }
        public StreetLevelCrimesModel[] Crimes { get; set; }
        public bool CrimesLoaded { get; set; }
        //private List<string> GetTotalUniqueCategories()
        //{
        //    if (Crimes.Count() > 0)
        //    {
        //        var categories = new List<string>();
        //        foreach (var cat in Crimes)
        //        {
        //            categories.Add(cat.category);
        //        }
        //        return categories.Distinct().ToList();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
