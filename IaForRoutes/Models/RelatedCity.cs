using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class RelatedCity
    {
        public City City { get; set; }
        public int Distance { get; set; }
        public int DistanceTotal { get; }

        public RelatedCity(City city, int distance)
        {
            City = city;
            Distance = distance;
            //distance to next node + distance to objective 
            DistanceTotal = Distance + City.DistanceGoal;
        }
    }
}