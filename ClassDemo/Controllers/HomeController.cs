using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Models;
using ERP.Project.Data.Context;
using System.IO;
using System.Data.Entity;
using static ClassDemo.Controllers.BaseController;

//dummycomment
namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class HomeController : BaseController
    {
 
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
            return View();
        }

        
        public ActionResult ItemsList()
        {
            TrackerItem ti = new TrackerItem();

            ViewBag.Project = new SelectList(db.projects, "ProjectId", "ProjectName");
            ViewBag.CategoryVB = new SelectList(db.ItemCategories, "CategoryId", "CategoryName");
            ViewBag.ItemTypeVB = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName");
            ViewBag.ItemStatusVB = new SelectList(db.ItemStatuses, "ItemStatusId", "ItemStatusName");
            ViewBag.ItemPriorityVB = new SelectList(db.ItemPriorities, "PriorityId", "PriorityName");

            var res= db.TrackerItems.Include(m => m.project).Include(m => m.ItemCategory).Include(m => m.ItemType).Include(m => m.ItemStatus).Include(m => m.ItemPriority).ToList() ;
            return View(res);
           
        }
        [HttpPost]
        public ActionResult ItemsList(TrackerItem ti)
        {
            ViewBag.Project = new SelectList(db.projects, "ProjectId", "ProjectName");
            ViewBag.CategoryVB = new SelectList(db.ItemCategories, "CategoryId", "CategoryName");
            ViewBag.ItemTypeVB = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName");
            ViewBag.ItemStatusVB = new SelectList(db.ItemStatuses, "ItemStatusId", "ItemStatusName");
            ViewBag.ItemPriorityVB = new SelectList(db.ItemPriorities, "PriorityId", "PriorityName");
            
            var items = db.TrackerItems.Where(m => m.ItemCategoryId == ti.ItemCategoryId || m.ItemStatusId == ti.ItemStatusId || m.ItemTypeId == ti.ItemTypeId || m.ItemProjectId == ti.ItemProjectId || m.ItemPriorityId == ti.ItemPriorityId);
            return View(items);
        }
        public ActionResult CreateItem()
        {
            //ViewBag.ItemId = db.TrackerItems.Max(p => p.ItemId) + 1;
            int dat = db.TrackerItems.Select(m => m.ItemId).Count();
            if (dat == 0)
            {
                ViewBag.ItemId = 1;
            }
            else
            {
                ViewBag.ItemId = db.TrackerItems.Max(p => p.ItemId) + 1;
               
            }

            ViewBag.Project = new SelectList(db.projects, "ProjectId", "ProjectName");
            ViewBag.CategoryVB = new SelectList(db.ItemCategories, "CategoryId", "CategoryName");
            ViewBag.ItemTypeVB = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName");
            ViewBag.ItemStatusVB = new SelectList(db.ItemStatuses, "ItemStatusId", "ItemStatusName");
            ViewBag.ItemPriorityVB = new SelectList(db.ItemPriorities, "PriorityId", "PriorityName");
            TrackerItem itm = new TrackerItem();
            return View(itm);
        }
        [HttpPost]
        public ActionResult CreateItem(TrackerItem itm, HttpPostedFileBase file)
        {
            var fileName = String.Empty;
            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/upload_attachements"), fileName);
                file.SaveAs(path);
            }
            if (ValidateForm(itm))
            {
                if (ModelState.IsValid)
                {
                    db.TrackerItems.Add(itm);
                    db.SaveChanges();
                    return RedirectToAction("ItemsList", "Home");
                }
            }         
            return View();
        }
        public ActionResult Edit(int ID)
        {
            ViewBag.CategoryVB = new SelectList(db.ItemCategories.Select(m => m.CategoryId));
            ViewBag.ItemTypeVB = new SelectList(db.ItemTypes.Select(m => m.ItemTypeId));
            ViewBag.ItemStatusVB = new SelectList(db.ItemStatuses.Select(m => m.ItemStatusId));
            ViewBag.ItemPriorityVB = new SelectList(db.ItemPriorities.Select(m => m.PriorityId));

            TrackerItem itm = db.TrackerItems.Find(ID);

            return View(itm);
        }
        [HttpPost]
        public ActionResult Edit(TrackerItem itm)
        {
            db.Entry(itm).State = EntityState.Modified;
            db.SaveChanges(); 
            return RedirectToAction("ItemsList");
        }
        
        private bool ValidateForm(TrackerItem itm)
        {

            //if (itm.ItemId == 0)
            //    ModelState.AddModelError("ItemId", "Please enter Item Id.");
            if (itm.ItemSummary == null)
                ModelState.AddModelError("ItemSummary", "Please enter ItemSummary");
            //else if (itm.ItemCategoryId == 0)
            //    ModelState.AddModelError("ItemCategoryId", "Please enter ItemCategory");
            //else if (itm.ItemType == "")
            //    ModelState.AddModelError("ItemType", "Please enter ItemCategory");
            //else if (itm.ItemPriority == 0)
            //    ModelState.AddModelError("Priority", "Please enter Priority");
            else if (itm.ItemCreatedDate == null)
                ModelState.AddModelError("ItemCreatedDate", "Please enter Date");
            else if (itm.CreatedBy == null)
                ModelState.AddModelError("CreatedBy", "Please enter CreatedBy");
            else if (itm.Owner == null)
                ModelState.AddModelError("Owner", "Please enter Owner");
            //else if (itm.Impact == null)
            //    ModelState.AddModelError("Impact", "Please enter Impact");
            //else if (itm.Resolution == null)
            //    ModelState.AddModelError("Resolution", "Please enter Resolution");
            else if (itm.ResolvedDate == null)
                ModelState.AddModelError("Resolved", "Please enter Resolved");
            return ModelState.IsValid;
        }

        public ActionResult DetailsView(int Id)
        {
            TrackerItem itm = db.TrackerItems.Find(Id);

            return View(itm);

        }
        [HttpPost]
        public ActionResult DetailsView(TrackerItem vm)
        {
            return RedirectToAction("Edit");
        }
        public ActionResult Delete(int Id)
        {
            TrackerItem itm = db.TrackerItems.Find(Id);
            db.TrackerItems.Remove(itm);
            db.SaveChanges();
            return RedirectToAction("ItemsList");
        }
    }
}