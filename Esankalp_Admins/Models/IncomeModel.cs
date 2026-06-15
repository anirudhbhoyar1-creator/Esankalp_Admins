using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistrationList.Data;

namespace Esankalp_Admins.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> IncomeDate { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public class IncomeDashboard
        {
            public decimal ThisMonthIncome { get; set; }

            public decimal TotalIncome { get; set; }

            public decimal PendingIncome { get; set; }

            public string TopClient { get; set; }
        }
            public string SaveIncome(IncomeModel model)
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            IncomeMaster im =
                new IncomeMaster();

            im.ClientName = model.ClientName;
            im.Amount = model.Amount;
            im.IncomeDate = model.IncomeDate;
            im.Category = model.Category;
            im.Notes = model.Notes;
            im.CreatedDate = model.CreatedDate;
            db.IncomeMasters.Add(im);

            db.SaveChanges();

            return "Income Saved Successfully";
        }

        public List<IncomeMaster> GetIncomeList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.IncomeMasters
                     .OrderByDescending(x => x.Id)
                     .ToList();
        }

        public IncomeDashboard GetDashboard()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            IncomeDashboard dashboard =
                new IncomeDashboard();

            dashboard.ThisMonthIncome =
                db.IncomeMasters
                .Where(x => x.IncomeDate.Value.Month ==
                            DateTime.Now.Month
                         && x.IncomeDate.Value.Year ==
                            DateTime.Now.Year)
                .Sum(x => (decimal?)x.Amount) ?? 0;

            dashboard.TotalIncome =
                db.IncomeMasters
                .Sum(x => (decimal?)x.Amount) ?? 0;

            dashboard.TopClient =
                db.IncomeMasters
                .GroupBy(x => x.ClientName)
                .OrderByDescending(g => g.Sum(x => x.Amount))
                .Select(g => g.Key)
                .FirstOrDefault();

            return dashboard;
        }
    }
}

