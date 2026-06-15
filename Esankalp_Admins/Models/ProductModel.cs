using Esankalp_Admins.Models;
using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string SaveProduct(ProductModel model)
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            ProductMaster pm =
                new ProductMaster();

            pm.ProductName = model.ProductName;
            pm.Category = model.Category;
            pm.Price = model.Price;
            pm.Status = model.Status;
            pm.Description = model.Description;

            db.ProductMasters.Add(pm);

            db.SaveChanges();

            return "Product Saved Successfully";
        }

        public List<ProductMaster> GetProductList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.ProductMasters.ToList();
        }
    }
}
