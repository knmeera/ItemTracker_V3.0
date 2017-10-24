using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ERP.Project.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Project.Data.Models
{
    public class ItemType
    {
        [Key]
        public int ItemTypeId { set; get; }
        public string ItemName { set; get; }
        public string ColorCode { get; set; }

        public ICollection<TrackerItem> TrackerItems { get; set; }

    }
    
}