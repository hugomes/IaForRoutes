using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IaForRoutes.Models;
using Microsoft.Ajax.Utilities;

namespace IaForRoutes.Controllers
{
    public class LineController : Controller
    {
        private static LineViewModel lineViewModel { get; set; }
        private List<OutInfo> OutInfo { get; set; }

        public LineController()
        {
            if (lineViewModel == null)
                lineViewModel = new LineViewModel();
            OutInfo = new List<OutInfo>();
        }

        public LineController(int size)
        {
            if (lineViewModel == null)
                lineViewModel = new LineViewModel();
            lineViewModel.Size = size;
            lineViewModel.CityList = new City[size];
            lineViewModel.StartLine = 0;
            lineViewModel.EndLine = -1;
            lineViewModel.QtdLine = 0;
        }

        public void ToQueue(City city)
        {
            if (!IsFull())
            {
                if (lineViewModel.EndLine == lineViewModel.Size - 1)
                {
                    lineViewModel.EndLine = -1;
                }

                lineViewModel.CityList[++lineViewModel.EndLine] = city;
                lineViewModel.QtdLine++;
            }
            else
            {
                throw new Exception("Line is full."); 
            }
        }

        public City UndoQueue()
        {
            if (!IsEmpty())
            {
                //lineViewModel.StartLine++, use lineViewModel.StartLine and later add 1
                City city = lineViewModel.CityList[lineViewModel.StartLine++];
                if (lineViewModel.StartLine == lineViewModel.Size)
                    lineViewModel.StartLine = 0;
                lineViewModel.QtdLine--;
                return city;
            }
            else
            {
                return null;
                throw new Exception("Line is empty.");
            }
        }

        public City GetFirst()
        {
            return lineViewModel.CityList[lineViewModel.StartLine];
        }

        public bool IsEmpty()
        {
            return lineViewModel.QtdLine == 0;
        }

        public bool IsFull()
        {
            return lineViewModel.QtdLine == lineViewModel.Size;
        }

        // GET: Line
        public ActionResult Index()
        {
            LineController lineController = new LineController(5);
            Map map = new Map();
            lineController.ToQueue(map.Araucaria);
            lineController.ToQueue(map.BalsaNova);
            lineController.ToQueue(map.Contenda);

            lineController.UndoQueue();
            lineController.UndoQueue();

            lineController.ToQueue(map.Canoinhas);
            lineController.ToQueue(map.Irati);
            lineController.ToQueue(map.Palmeira);
            lineController.ToQueue(map.PortoUniao);

            OutInfo.Add(new OutInfo("First", GetFirst().Name));
            return View(OutInfo);
        }
    }
}