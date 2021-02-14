using NEXT.Project.SuperForum.Business;
using NEXT.Project.SuperForum.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            return View();
        }

        public ActionResult Contact()
        {
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
                    var sha1 = new SHA1CryptoServiceProvider();
                    var data = Encoding.ASCII.GetBytes(userLogin.Password);
                    var encrypted = sha1.ComputeHash(data);
                    var password = Encoding.ASCII.GetString(encrypted);
                    if (result.Result.Password == password)
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

        public ActionResult Logout()
        {
            Session["UserLoggedInId"] = null;
            Session["UserLoggedInName"] = null;
            return RedirectToAction("Index");
        }
    }
}