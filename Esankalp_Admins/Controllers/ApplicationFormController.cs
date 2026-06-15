using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Esankalp_Admins.Controllers
{
    public class ApplicationFormController : Controller
    {
        // GET: ApplicationForm
        public ActionResult Index()
        {
            return RedirectToAction("ApplicationForm");
        }
        public ActionResult ApplicationForm()
        {
            return View();
        }
        public JsonResult SaveApplication(ApplicationModel model)
        {
            try
            {
                ApplicationModel cm =
                    new ApplicationModel();

                return Json(new
                {
                    Message = cm.SaveApplication(model)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}