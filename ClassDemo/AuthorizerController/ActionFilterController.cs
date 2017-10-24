using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Project.Data.Context;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    public class BaseController : Controller
    {
        public class IsAdmin : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                base.OnActionExecuting(context);
                HttpSessionStateBase session = context.HttpContext.Session;

                if (session.IsNewSession || context.HttpContext.Session["Authorize"] == null)
                {
                    context.HttpContext.Session["Authorize"] = 0;
                }
                int ID = (int)context.HttpContext.Session["Authorize"];
                if (ID == 0)
                {
                    var Action = context.ActionDescriptor.ActionName;
                    if (Action == "About" || Action == "Index" || Action == "Contact" || Action == "Login" || Action == "LogOut")
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new RedirectResult("~/Login/UnauthorisedUser");
                    }
                }
                if (ID == 1)
                {
                    context.HttpContext.Session["Authorize"] = 1;
                    var Action = context.ActionDescriptor.ActionName;
                    if (Action == "About" || Action == "Index" || Action == "Contact" || Action == "ItemsList" || Action == "DetailsView" || Action == "Login" || Action == "LogOut" || Action== "Details")
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new RedirectResult("~/Login/UnauthorisedUser");
                    }
                }
                if (ID == 2)
                {
                    var Action = context.ActionDescriptor.ActionName;
                    context.HttpContext.Session["Authorize"] = 2;
                }
                else
                {
                    context.Result = new RedirectResult("~/Login/UnauthorisedUser");
                }
            }
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                //filterContext=
                base.OnActionExecuted(filterContext);
                var result = filterContext.Result as ViewResult;
                HttpSessionStateBase session = filterContext.HttpContext.Session;

                if (session.IsNewSession || filterContext.HttpContext.Session["Authorize"] == null)
                {
                    filterContext.HttpContext.Session["Authorize"] = 0;
                }
                if (result != null)
                {
                    int ID = (int)filterContext.HttpContext.Session["Authorize"];
                    switch (ID.ToString())
                    {
                        case "0":
                            {
                                result.MasterName = "~/Views/Shared/_UserLayout.cshtml";
                            }
                            break;
                        case "1":
                            {
                                result.MasterName = "~/Views/Shared/_EmpLayout.cshtml";
                            }
                            break;
                        case "2":
                            {
                                result.MasterName = "~/Views/Shared/_Layout.cshtml";
                            }
                            break;
                    }
                }
            }
        }
    }
}
