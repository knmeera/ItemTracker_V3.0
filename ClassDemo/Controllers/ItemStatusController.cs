using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassDemo.Models;
using ERP.Project.Data.Context;
using ERP.Project.Data.Models;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class ItemStatusController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemStatusView()
        {
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            ItemStatus stat = new ItemStatus();
            return View(db.ItemStatuses.ToList());
        }
        [HttpPost]
        public ActionResult ItemStatusView(ItemStatus stat)
        {
            if(ModelState.IsValid)
            {
                ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
                db.ItemStatuses.Add(stat);
                db.SaveChanges();
                return RedirectToAction("ItemStatusView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            ItemStatus stat = db.ItemStatuses.Find(id);
            db.ItemStatuses.Remove(stat);
            db.SaveChanges();
            return RedirectToAction("ItemStatusView");
        }
        public ActionResult Edit(int id)
        {
            ItemStatus stat = db.ItemStatuses.Find(id);
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            return View(stat);
        }
        [HttpPost]
        public ActionResult Edit(ItemStatus stat)
        {
            ViewBag.ColorCode = new SelectList(Colors.GetColors(), "Value", "Text");
            db.Entry(stat).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ItemStatusView");
        }
    }
}