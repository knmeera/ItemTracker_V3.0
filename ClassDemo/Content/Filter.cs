using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.Project.Data.Context;

namespace ClassDemo.Content
{
    public class Filter
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public IQueryable FilterItems()
        {
            Filter filter = new Filter();
            var item =db.TrackerItems;
            return item ;
        }
        public int filter()
        {
            var x=0;
            return x; 
        }
    }
}