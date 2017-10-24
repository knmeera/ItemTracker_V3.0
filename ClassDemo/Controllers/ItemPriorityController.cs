using ERP.Project.Data.Context;
using ERP.Project.Data.Models;
using ClassDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class ItemPriorityController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemPriorityView()
        {
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            ItemPriority prio = new ItemPriority();
            return View(db.ItemPriorities.ToList());
        }
        [HttpPost]
        public ActionResult ItemPriorityView(ItemPriority prio)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
                db.ItemPriorities.Add(prio);
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            ItemPriority prio = db.ItemPriorities.Find(id);
            return View(prio);
        }
        [HttpPost]
        public ActionResult Edit(ItemPriority prio)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
                db.Entry(prio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View(prio);
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                ItemPriority pri = db.ItemPriorities.Find(id);
                db.ItemPriorities.Remove(pri);
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View();
        }
    }
}