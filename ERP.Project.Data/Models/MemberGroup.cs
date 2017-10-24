using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Project.Data.Models
{
    public class MemberGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<Member> Members { get; set; }
        //id
        //groupname
        //enable(bool)
        //total number of member

    }
}