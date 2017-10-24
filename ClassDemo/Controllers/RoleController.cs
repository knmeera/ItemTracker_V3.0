using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Context;
using ERP.Project.Data.Models;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class RoleController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        // GET: Role
        public ActionResult RoleView()
        {
            Role rol = new Role();
            return View(db.Roles.ToList());
        }
        [HttpPost]
        public ActionResult RoleView(Role rol)
        {
            if(ModelState.IsValid)
            {
                db.Roles.Add(rol);
                db.SaveChanges();
                return RedirectToAction("RoleView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Role ro = db.Roles.Find(id);
            db.Roles.Remove(ro);
            db.SaveChanges();
            return RedirectToAction("RoleView");
        }
        public ActionResult Edit(int id)
        {
            Role ro = db.Roles.Find(id);

            return View(ro);
        }
        [HttpPost]
        public ActionResult Edit(Role ro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RoleView");
            }
            return View();
        }
    }
}