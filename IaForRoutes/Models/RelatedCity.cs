using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class RelatedCity
    {
        public City City { get; set; }

        public RelatedCity(City city)
        {
            City = city;
        }
    }
}