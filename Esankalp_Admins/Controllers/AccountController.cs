using System.Web.Mvc;

namespace YourProject.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(string name, string mobile)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}

