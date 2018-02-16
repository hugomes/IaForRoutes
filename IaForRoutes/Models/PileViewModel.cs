using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class PileViewModel
    {
        public int Size { get; set; }
        public City[] CityList { get; set; }
        public int Top { get; set; }
        public City City { get; set; }
    }
}