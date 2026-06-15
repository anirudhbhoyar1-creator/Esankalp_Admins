using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esankalp_Admins.Models
{
    public class PortfolioModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Category { get; set; }
        public string Technologies { get; set; }
        public string ProjectUrl { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public List<PortfolioMaster> GetPortfolioList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.PortfolioMasters
                     .OrderByDescending(x => x.Id)
                     .ToList();
        }
    }
}