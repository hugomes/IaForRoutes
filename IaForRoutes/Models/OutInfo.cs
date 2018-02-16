using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class OutInfo
    {
        public string Title { get; set; }
        public string Value { get; set; }

        public OutInfo(string title, string value)
        {
            Title = title;
            Value = value;
        }
    }
}