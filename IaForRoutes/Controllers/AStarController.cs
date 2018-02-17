using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class AStarController : Controller
    {
        private VectorRelatedCityController VectorRelatedCityController { get; set; }
        private City EndCity { get; set; }
        private bool Found { get; set; }
        public List<OutInfo> OutInfoList { get; set; }

        public void Start(City endCity)
        {
            OutInfoList = new List<OutInfo>();
            EndCity = endCity;
            Found = false;
        }

        public void Search(City actualCity)
        {
            OutInfoList.Add(new OutInfo("Actual City", actualCity.Name));
            actualCity.Visited = true;
            if (actualCity == EndCity)
            {
                Found = true;
            }
            else
            {
                VectorRelatedCityController = new VectorRelatedCityController();
                VectorRelatedCityController.Start(actualCity.RelatedCityList.Count);
                foreach (RelatedCity relatedCity in actualCity.RelatedCityList)
                {
                    if (!relatedCity.City.Visited)
                    {
                        relatedCity.City.Visited = true;
                        VectorRelatedCityController.Add(relatedCity);
                    }
                }

                OutInfoList.AddRange(VectorRelatedCityController.ShowAllOutInfos());
                Search(VectorRelatedCityController.GetCityLessDistance());
            }
        }

        // GET: AStar
        public ActionResult Index()
        {
            Map map = new Map();
            Start(map.Curitiba);
            Search(map.PortoUniao);
            return View(OutInfoList);
        }
    }
}