using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Esankalp_Admins.Controllers
{
    public class ApplicationListController : Controller
    {
        // GET: ApplicationList
        public ActionResult Index()
        {
            return RedirectToAction("ApplicationList");
        }
        public ActionResult ApplicationList()
        {
            ApplicationModel model = new ApplicationModel();

            var data = model.GetApplicationList();

            return View(data);
        }
       
    }
}