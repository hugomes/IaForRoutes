using IaForRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IaForRoutes.Controllers
{
    public class PileController : Controller
    {
        public static PileViewModel pileViewModel { get; set; }
        public PileController()
        {
            if (pileViewModel == null)
                pileViewModel = new PileViewModel();
        }

        public PileController(int size)
        {
            if (pileViewModel == null) 
                pileViewModel = new PileViewModel();
            pileViewModel.Size = size;
            pileViewModel.CityList = new City[size];
            pileViewModel.Top = -1;
        }

        public void StackUp(City city)
        {
            if (!IsFull())
            {
                //++Top, sum 1 to Top and later use Top
                pileViewModel.CityList[++pileViewModel.Top] = city;
            }
            else
            {
                throw new Exception("The list is full.");
            }
        }

        /// <summary>
        /// Get the last City object in pile
        /// </summary>
        /// <returns>Last City object in pile CityList</returns>
        public City ToUnpack()
        {
            if (!IsEmpty())
            {
                //Top--, use Top and later reduce 1
                return pileViewModel.CityList[pileViewModel.Top--];
            }
            else
            {
                throw new Exception("The list is empty.");
            }
        }

        public City GetTopObject()
        {
            return pileViewModel.CityList[pileViewModel.Top];
        }

        public bool IsFull()
        {
            return (pileViewModel.CityList.Count() - 1) == pileViewModel.Top;
        }

        public bool IsEmpty()
        {
            return pileViewModel.CityList.Count() == 0;
        }

        //GET: /Pile/ListCities
        public ActionResult ListCities()
        {
            PileController pileController = new PileController(3);
            Map map = new Map();

            pileController.StackUp(map.PortoUniao);
            pileController.StackUp(map.CampoLargo);
            pileController.StackUp(map.Canoinhas);

            pileViewModel.CityList = pileViewModel.CityList.Where(c=>c != pileController.ToUnpack()).ToArray() ;

            return View(pileViewModel);
        }
    }
}