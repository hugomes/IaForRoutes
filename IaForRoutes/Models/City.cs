using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class City
    {
        public string Name { get; set; }
        public bool Visited { get; set; }
        public int DistanceGoal { get; set; }
        public List<RelatedCity> RelatedCityList { get; }

        public City(string name, int distanceGoal)
        {
            Name = name;
            Visited = false;
            DistanceGoal = distanceGoal;
            RelatedCityList = new List<RelatedCity>();
        }

        public void AddRelatedCities(RelatedCity relatedCity)
        {
            RelatedCityList.Add(relatedCity);
        }
    }
}