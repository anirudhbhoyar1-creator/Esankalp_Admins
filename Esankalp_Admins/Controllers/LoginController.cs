using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Esankalp_Admins.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult LoginIN(LoginModel model)
        {
            if (model.UserName == "Admin" &&
                model.Password == "trishul@123")
            {
                FormsAuthentication.SetAuthCookie(
                    model.UserName,
                    false
                );

                return RedirectToAction(
                    "Index",
                    "Dashboard"
                );
            }

            ModelState.AddModelError("", "Invalid Login");

            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}

