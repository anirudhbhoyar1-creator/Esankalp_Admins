using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class ClientListController : Controller
    {
        // GET: ClientList
        public ActionResult Index()
        {
            return RedirectToAction("ClientList");
        }
        public ActionResult ClientList()
        {
            ClientModel cm = new ClientModel();

            var data = cm.GetClientList();

            return View(data);
        }
    }
}
       