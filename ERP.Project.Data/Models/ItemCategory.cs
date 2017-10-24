using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ERP.Project.Data.Context;
using System.ComponentModel.DataAnnotations;

namespace ERP.Project.Data.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string ColorCode { get; set; }

        public ICollection<TrackerItem> TrackerItems { get; set; }
    }
}