using Esankalp_Admins.Models;
using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {


            return RedirectToAction("Portfolio");
        }
        public ActionResult Portfolio()
        {
            PortfolioModel model =
                new PortfolioModel();

            var list =
                model.GetPortfolioList();

            return View(list);
        }
    }
}