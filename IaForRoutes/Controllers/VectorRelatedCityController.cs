using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;

namespace IaForRoutes.Controllers
{
    public class VectorRelatedCityController : Controller
    {
        private RelatedCity[] RelatedCitiesList { get; set; }

        private int NumFields { get; set; }
        private List<OutInfo> OutInfoList { get; set; }

        public void Start(int size)
        {
            RelatedCitiesList = new RelatedCity[size];
            NumFields = 0;
            OutInfoList = new List<OutInfo>();
        }

        public void Add(RelatedCity relatedCity)
        {
            int pos;
            for (pos = 0; pos < NumFields; pos++)
            {
                //stop loop on position element with distance less than city(parameter) to insert in that position
                if (RelatedCitiesList[pos].DistanceTotal > relatedCity.DistanceTotal)
                {
                    break;
                }
            }

            for (int i = NumFields; i > pos; i--)
            {
                RelatedCitiesList[i] = RelatedCitiesList[i - 1];
            }

            RelatedCitiesList[pos] = relatedCity;
            NumFields++;
        }

        public City GetCityLessDistance()
        {
            return RelatedCitiesList.First().City;
        }

        public List<OutInfo> ShowAllOutInfos()
        {
            for (int i = 0; i < NumFields; i++)
            {
                OutInfoList.Add(new OutInfo("City", RelatedCitiesList[i]. City.Name + " - " + RelatedCitiesList[i].DistanceTotal));
            }
            return OutInfoList;
        }
    }
}