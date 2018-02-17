using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class HungrySearchController : Controller
    {
        public  VectorController VectorController { get; set; }
        public City EndCity { get; set; }
        public bool Found { get; set; }
        public List<OutInfo> OutInfoList { get; set; }

        public void Start(City endCity)
        {
            OutInfoList = new List<OutInfo>();
            EndCity = endCity;
            Found = false;
        }

        public void Search(City currentCity)
        {
            OutInfoList.Add(new OutInfo("Current City", currentCity.Name));
            currentCity.Visited = true;
            if (currentCity == EndCity)
            {
                Found = true;
            }
            else
            {
                VectorController = new VectorController();
                VectorController.Start(currentCity.RelatedCityList.Count);
                foreach (RelatedCity relatedCity in currentCity.RelatedCityList)
                {
                    if (!relatedCity.City.Visited)
                    {
                        relatedCity.City.Visited = true;
                        VectorController.Add(relatedCity.City);
                    }
                }

                OutInfoList.AddRange(VectorController.ShowAllOutInfos());
                if (VectorController.GetCityLessDistance() != null)
                {
                    Search(VectorController.GetCityLessDistance());
                }
            }

        }

        // GET: HungrySearch
        public ActionResult Index()
        {
            Map map = new Map();
            Start(map.Curitiba);
            Search(map.PortoUniao);
            return View(OutInfoList);
        }
    }
}