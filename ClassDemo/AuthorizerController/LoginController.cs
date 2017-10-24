using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Context;
using ERP.Project.Data.Models;

namespace ClassDemo.Controllers
{
    public class LoginController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult Login()
        {
            Member reg = new Member();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Member reg)
        {
            Session["UserId"] = null;
            Session["Authorize"] = 0;
            Session["UserName"] = null;

            if (reg.UserName != "" && reg.UserName != null && reg.Password != "" && reg.Password != null)
            {
                int LoginCountStatus = db.Logins.Where(m => m.username == reg.UserName && m.password == reg.Password).Count();
                int UserCountStatus = db.Members.Where(m => m.UserName == reg.UserName && m.Password == reg.Password).Count();
                int Usercount = db.Members.Where(m => m.UserName == reg.UserName).Count();
                int LoginCount = db.Logins.Where(m => m.username == reg.UserName).Count();

                if (UserCountStatus != 1 && LoginCountStatus != 1)
                {
                    if (Usercount == 0 && LoginCount == 0)
                    {
                        ViewBag.Login = "User Does Not Exist";
                    }
                    if (Usercount == 1 && LoginCount == 0)
                    {
                        ViewBag.Password = "Password is Incorect";
                    }
                }
                if (UserCountStatus == 1)
                {
                    //store data in 

                    var user = db.Members.Where(m => m.UserName == reg.UserName).SingleOrDefault();
                    Session["UserId"] = user.RegId;
                    Session["Authorize"] = 1;
                    Session["UserName"] = user.UserName;

                    return RedirectToAction("Index", "Home");
                }
                if (LoginCountStatus == 1)
                {
                    var user = db.Logins.Where(m => m.username == reg.UserName).SingleOrDefault();
                    Session["Authorize"] = 2;
                    Session["UserName"] = user.username;
                    Session["UserId"] = user.Id;
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();

        }
        public ActionResult LogOut()
        {
            Session["Authorize"] = 0;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult UnauthorisedUser()
        {
            Session["UserId"] = null;
            Session["Authorize"] = 0;
            Session["UserName"] = null;
            Session["Authorize"] = 0;
            return View();
        }
    }
}