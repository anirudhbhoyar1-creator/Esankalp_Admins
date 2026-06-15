using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class ContactListController : Controller
    {
        // GET: ContactList
        public ActionResult Index()
        {
            return RedirectToAction("ContactList");
        }
        public ActionResult ContactList()
        {
            ContactModel cm =
                new ContactModel();

            var data =
                cm.GetContactList();

            return View(data);
        }
    }
}