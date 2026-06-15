using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class IncomeController : Controller
    {
        // GET: Income
        public ActionResult Index()
        {
            return RedirectToAction("Income");
        }
        public ActionResult Income()
        {
            var data = new IncomeModel().GetIncomeList();

            var dashboard = new IncomeModel().GetDashboard();

            ViewBag.TotalIncome = dashboard.TotalIncome;
            ViewBag.ThisMonthIncome = dashboard.ThisMonthIncome;
            ViewBag.TopClient = dashboard.TopClient;
            ViewBag.TotalRecords = data.Count();

            return View(data);
        }
        [HttpPost]
        public JsonResult SaveIncome(IncomeModel model)
        {
            try
            {
                return Json(new
                {
                    Message =
                    new IncomeModel().SaveIncome(model)
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = ex.Message
                });
            }
        }

        public JsonResult GetIncomeList()
        {
            try
            {
                return Json(new
                {
                    model =
                    new IncomeModel().GetIncomeList()
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

        public JsonResult GetDashboard()
        {
            return Json(new
            {
                model =
                new IncomeModel().GetDashboard()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
