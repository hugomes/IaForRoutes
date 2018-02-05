using IaForRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Controllers
{
    public class PileController
    {
        private int Size { get; set; }
        private City[] CityList { get; set; }
        private int Top { get; set; }

        public PileController(int size)
        {
            Size = size;
            CityList = new City[size];
            Top = -1;
        }

        public void StackUp(City city)
        {
            if (!IsFull())
            {
                //++Top, sum 1 to Top and later use Top
                CityList[++Top] = city;
            }
        }

        public City ToUnpack()
        {
            if (!IsEmpty())
            {
                //Top--, use Top and later reduce 1
                return CityList[Top--];
            }
            else
            {
                throw new Exception("The list is empty.");
            }
        }

        public City GetTopObject()
        {
            return CityList[Top];
        }

        public bool IsFull()
        {
            return (CityList.Count() - 1) == Top;
        }

        public bool IsEmpty()
        {
            return CityList.Count() == 0;
        }

        public static void PilhaView()
        {
            PileController pileController = new PileController(5);
            Map map = new Map();

            StackUp(map.PortoUniao);
        }
    }
}