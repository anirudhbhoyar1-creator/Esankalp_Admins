using Esankalp_Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Controllers
{
    public class AddProductController : Controller
    {
        // GET: AddProduct
        public ActionResult Index()
        {
            return RedirectToAction("AddProduct");
        }
        public ActionResult AddProduct()
        {
            ProductModel pm =
                new ProductModel();

            var data =
                pm.GetProductList();

            return View(data);
        }

        [HttpPost]
        public JsonResult SaveProduct(ProductModel model)
        {
            try
            {
                return Json(new
                {
                    Message =
                    (new ProductModel().SaveProduct(model))
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