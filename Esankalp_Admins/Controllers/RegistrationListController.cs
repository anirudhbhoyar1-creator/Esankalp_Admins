using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class RegistrationListController : Controller
    {
        // GET: RegistrationList
        public ActionResult Index()
        {
            return View("RegistrationList");
        }
        public ActionResult RegistrationList()
        {
            return View();
        }
        public JsonResult GetRegistration( string Name)
        {
            RegistrationModel rm = new RegistrationModel();

            return Json(new
            {
                data = rm.GetRegistration(Name)
            }, JsonRequestBehavior.AllowGet);
        }
    }

}