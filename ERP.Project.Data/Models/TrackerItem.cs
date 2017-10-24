using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ERP.Project.Data.Models;
using ERP.Project.Data.Context;
using System.ComponentModel.DataAnnotations.Schema;



namespace ERP.Project.Data.Models
{

    public class TrackerItem
    {
        public int ItemId { set; get; }
        public string ProjectName { set; get; }
        public string ItemSummary { set; get; }
        public string ItemCreatedDate { set; get; }
        public string AssignedDate { set; get; }
        public string ItemEndDate { set; get; }
        public string WorkCompleted { set; get; }    
        public string CreatedBy { set; get; }
        public string Owner { set; get; }
        public string Impact { set; get; }
        public string Resolution { set; get; }
        public string ResolvedDate { set; get; }
        public string AttachmentPath { set; get; }
        public int ParentId { get; set; }
        public string AssignedTo { get; set; }
        public string Subjet { get; set; }
        //forien keys
        public int ItemProjectId { get; set; }
        public int ItemCategoryId { set; get; }
        public int ItemTypeId { set; get; }
        public int ItemPriorityId { set; get; }
        public int ItemStatusId { set; get; }
        //relation one-to-many (one)
        public virtual project project { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemType ItemType { set; get; }
        public virtual ItemPriority ItemPriority { set; get; }
        public virtual ItemStatus ItemStatus { set; get; }
    }
}