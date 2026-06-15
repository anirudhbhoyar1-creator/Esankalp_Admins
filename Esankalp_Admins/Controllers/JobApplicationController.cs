using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class JobApplicationController : Controller
    {
        // GET: JobApplication
        public ActionResult Index()
        {
            return View("JobApplication");
        }
        public ActionResult JobApplication()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveJobApplication(JobApplicationModel model)
        {
            try
            {
                JobApplicationModel jm =
                    new JobApplicationModel();

                return Json(new
                {
                    Message = jm.SaveJobApplication(model)
                },
                JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = ex.Message
                },
                JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetJobApplicationList()
        {
            try
            {
                return Json(new
                {
                    model =
                    new JobApplicationModel()
                    .GetJobApplicationList()
                },
                JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = ex.Message
                },
                JsonRequestBehavior.AllowGet);
            }
        }
    }
}
   