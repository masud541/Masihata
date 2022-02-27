using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MAM.Models;

namespace MAM.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserInfo model)
        {
            using (var context = new MAMDBEntities())
            {
                context.UserInfoes.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfo model)
        {
            using (var context = new MAMDBEntities())
            {
                bool isValid =  context.UserInfoes.Any(x=>x.UserName == model.UserName && x.Password == model.Password);
                
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("", "Invalid Username or Password");

                return View();
            }           
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}