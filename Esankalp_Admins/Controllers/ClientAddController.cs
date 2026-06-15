using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class ClientAddController : Controller
    {
        // GET: ClientAdd
        public ActionResult Index()
        {
            return RedirectToAction("ClientAdd");
        }
        public ActionResult ClientAdd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveClient(ClientModel model)
        {
            try
            {
                ClientModel cm = new ClientModel();

                return Json(new
                {
                    Message = cm.SaveClient(model)
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