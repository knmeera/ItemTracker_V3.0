using ERP.Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Context;
using System.Data.Entity;
using static ClassDemo.Controllers.BaseController;

namespace ClassDemo.Controllers
{
    [IsAdmin]
    public class MemberController : BaseController
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
      
        public ActionResult AddMember()
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            Member reg = new Member();
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member reg)
        {
            int user = db.Members.Where(m => m.UserName == reg.UserName).Count();
            int email = db.Members.Where(m => m.EmailId == reg.EmailId).Count();
            int userAd = db.Logins.Where(m => m.username == reg.UserName).Count();
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            if (ModelState.IsValid)
            {
                if (user == 0 && email == 0 && userAd==0)
                {
                    db.Members.Add(reg);
                    db.SaveChanges();
                    ViewBag.RegStatus = "Registerd Sucessfully";
                    return View();
                }
                if(user>=1 || userAd>=1)
                {
                    ViewBag.status = "username already exists";
                }
                if(email>=1)
                {
                    ViewBag.status = "email Id already exists";
                }
            }           
            return View();
        }
       
       
        public ActionResult Details()
        {
             var id = Session["UserId"];
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            var det = db.Members.Find(id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Details(Member det)
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            db.Entry(det).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Members()
        {

            return View(db.Members.Include(m=>m.Role).ToList());
        }
        public ActionResult AdminDetails()
        {
            var id = Session["UserId"];
            var det = db.Logins.Find(id);
            return View(det);
        }
        [HttpPost]
        public ActionResult AdminDetails(Member det)
        {
            if (ModelState.IsValid)
            {
                db.Entry(det).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            Member reg = db.Members.Find(Id);
            db.Members.Remove(reg);
            db.SaveChanges();
            return RedirectToAction("Members");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            var det = db.Members.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Edit(Member det)
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "UserRole");
            db.Entry(det).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Members");
        }
    }
}