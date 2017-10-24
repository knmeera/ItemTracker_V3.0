using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Project.Data.Models
{
    public class ItemTrackerUpdate
    {
        public int ID { set; get; }
        public int ItemId { set; get; }
        public string Update { set; get; }
        public DateTime UpdateDateTime { set; get; }
        public bool Enabled { set; get; }
    }
}