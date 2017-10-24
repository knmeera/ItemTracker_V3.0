using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassDemo.Models
{
    public class Colors
    {
        public static List<SelectListItem> GetColors()
        {
            List<SelectListItem> col = new List<SelectListItem>();
            col.Add(new SelectListItem { Value="#FF0000", Text = "Red" });
            col.Add(new SelectListItem { Value = "#FFFF00", Text = "Yellow" });
            col.Add(new SelectListItem { Value = "#00FF00", Text = "Green" });

            return col;
        }
       
    }
}