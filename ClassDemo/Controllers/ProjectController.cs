using ERP.Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Context;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class ProjectController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ProjectView()
        {
            project pro = new project();
            return View(db.projects.ToList());
        }
        [HttpPost]
        public ActionResult ProjectView(project pro)
        {
            if (ModelState.IsValid)
            {
                db.projects.Add(pro);
                db.SaveChanges();
                return RedirectToAction("ProjectView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            project pro = db.projects.Find(id);
            db.projects.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("ProjectView");
        }
        public ActionResult Edit(int id)
        {
            project pro = db.projects.Find(id);
            
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(project pro)
        {
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProjectView");
        }
    }
}