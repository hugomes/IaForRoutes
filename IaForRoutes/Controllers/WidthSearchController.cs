using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class WidthSearchController : Controller
    {
        public List<OutInfo> OutInfoList { get; set; }
        private LineController LineController;

        private City StartCity;
        private City EndCity;
        private bool Found;

        public WidthSearchController()
        {
        }

        public void Start(City startCity, City endCity)
        {
            OutInfoList = new List<OutInfo>();
            StartCity = startCity;
            StartCity.Visited = true;
            EndCity = endCity;

            LineController = new LineController(20);
            LineController.ToQueue(startCity);
        }

        public void Search()
        {
            City firstCity = LineController.GetFirst();
            OutInfoList.Add(new OutInfo("First", firstCity.Name));
            if (firstCity == EndCity)
            {
                Found = true;
            }
            else
            {

                OutInfoList.Add(new OutInfo("UndoQueue", LineController.UndoQueue().Name));
                foreach (RelatedCity relatedCity in firstCity.RelatedCityList)
                {
                    OutInfoList.Add(new OutInfo("Visited?", relatedCity.City.Name));

                    if (!relatedCity.City.Visited)
                    {
                        relatedCity.City.Visited = true;
                        LineController.ToQueue(relatedCity.City);
                    }

                }

                if (LineController.lineViewModel.QtdLine > 0)
                    Search();
            }
        }

        // GET: WidthSearch
        public ActionResult Index()
        {
            Found = false;

            Map map = new Map();
            Start(map.PortoUniao, map.Curitiba);
            Search();
            return View(OutInfoList);
        }
    }
}