using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Project.Data.Models
{
    public class ItemStatus
    {
       [Key]
        public int ItemStatusId { set; get; }
        public string ItemStatusName { set; get; }
        public string ColorCode { get; set; }

        public ICollection<TrackerItem> TrackerItems { get; set; }
        
    }
    
}