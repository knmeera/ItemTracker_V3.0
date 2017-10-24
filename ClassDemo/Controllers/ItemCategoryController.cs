using ERP.Project.Data.Context;
using ERP.Project.Data.Models;
using ClassDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassDemo.Controllers
{
    //[Authorize(Roles ="Admin")]
    [IsAdmin]
    public class ItemCategoryController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemCategoryView()
        {           
            using (var _dbContext = new ProjectManagementDbContext())
            {
                ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
                var itms = _dbContext.ItemCategories.ToList();
                return View(itms);
            }
        }
        [HttpPost]
        public ActionResult ItemCategoryView(ItemCategory cat )
        {
            if (ModelState.IsValid)
            {
                ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
                db.ItemCategories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("ItemCategoryView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            ItemCategory cat = db.ItemCategories.Find(id);
            db.ItemCategories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("ItemCategoryView");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            ItemCategory cat = db.ItemCategories.Find(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(ItemCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ItemCategoryView");
            }
            return View(cat);
        }

    }
}
