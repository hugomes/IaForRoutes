using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class DeepController : Controller
    {
        private PileController pile;

        private City startCity;

        private City endCity;

        private bool found;

        public List<OutInfo> outInfo = new List<OutInfo>();
        // GET: Deep
        public ActionResult Index()
        {
            found = false;
            Map map = new Map();
            Deep(map.PortoUniao, map.Curitiba);
            Search();
            var x = pile.GetCityList();
            return View(outInfo);
        }

        public void Deep(City start, City end)
        {
            startCity = start;
            startCity.Visited = true;
            endCity = end;

            pile = new PileController(20);
            pile.StackUp(startCity);
        }

        public void Search()
        {
            City topCity = pile.GetTopObject();
            outInfo.Add(new OutInfo("Top City: ", topCity.Name));
            if (topCity == endCity)
                found = true;
            else
            {
                foreach (RelatedCity relatedCity in topCity.RelatedCityList)
                {
                    if (!found)
                    {
                        outInfo.Add(new OutInfo("Visited? ", relatedCity.City.Name));
                        if (!relatedCity.City.Visited)
                        {
                            relatedCity.City.Visited = true;
                            pile.StackUp(relatedCity.City);
                            Search();
                        }
                    }
                }
            }

            outInfo.Add(new OutInfo("Unpack: ", pile.ToUnpack().Name));
        }
    }
}