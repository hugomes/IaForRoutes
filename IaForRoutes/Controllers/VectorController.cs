using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class VectorController : Controller
    {
        private City[] CityList { get; set; }

        private int NumFields { get; set; }
        private List<OutInfo> OutInfoList { get; set; }

        public void Start(int size)
        {
            CityList = new City[size];
            NumFields = 0;
            OutInfoList = new List<OutInfo>();
        }

        public void Add(City city)
        {
            int pos;
            for (pos = 0; pos < NumFields; pos++)
            {
                //stop loop on position element with distance less than city(parameter) to insert in that position
                if (CityList[pos].DistanceGoal > city.DistanceGoal)
                {
                    break;
                }
            }

            for (int i = NumFields; i > pos; i--)
            {
                CityList[i] = CityList[i - 1];
            }

            CityList[pos] = city;
            NumFields++;
        }

        public City GetCityLessDistance()
        {
            return CityList.First();
        }

        public List<OutInfo> ShowAllOutInfos()
        {
            for (int i = 0; i < NumFields; i++)
            {
                OutInfoList.Add(new OutInfo("City", CityList[i].Name + " - " + CityList[i].DistanceGoal));
            }

            return OutInfoList;
        }

        // GET: Vector
        public ActionResult Index()
        {
            Map map = new Map();
            Start(5);
            Add(map.PortoUniao);
            Add(map.PauloFrontin);
            Add(map.BalsaNova);
            Add(map.Palmeira);
            
            return View(ShowAllOutInfos());
        }
    }
}