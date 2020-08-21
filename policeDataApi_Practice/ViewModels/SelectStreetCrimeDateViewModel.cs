using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Months { get; set; }
    }
}
