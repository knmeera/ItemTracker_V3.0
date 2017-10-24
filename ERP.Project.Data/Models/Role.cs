using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Project.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string UserRole { get; set; }
        //membergroupid
        //superadmin
        //projectadmin
        //developer
        //Team lead
        //QA
        //

        public virtual ICollection<Member> Members { get; set; }
    }
}