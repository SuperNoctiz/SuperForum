using NEXT.Project.SuperForum.Business;
using NEXT.Project.SuperForum.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEXT.Project.SuperForum.Web.Controllers
{
    public class HomeController : Controller
    {

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var userBO = new UserBO();

                var result = userBO.Get(userLogin.Name);
                
                if (result.HasSucceeded)
                {
                    if (result.Result.Password == userLogin.Password)
                    {
                        Session["UserLoggedInId"] = result.Result.Id;
                        Session["UserLoggedInName"] = result.Result.Name;
                        return RedirectToAction("Index");
                    }
                }
                return HttpNotFound();
            }

            return View(userLogin);
        }
    }
}