using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esankalp_Admins.Models
{
    public class RegistrationModel
    {
        public int RegId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public decimal Percentage { get; set; }
        public string Service { get; set; }
        public string Technology { get; set; }
        public string Office { get; set; }
        public string College { get; set; }
        public string Address { get; set; }

        public List<RegistrationModel> GetRegistration()
        {
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();

            List<RegistrationModel> list = new List<RegistrationModel>();

            var data = db.Registrations.ToList();

            foreach (var item in data)
            {
                list.Add(new RegistrationModel()
                {
                    RegId = item.RegId,
                    Name = item.Name,
                    MobileNo = item.MobileNo,
                    Email = item.Email,
                    Education = item.Education,
                    Percentage = item.Percentage,
                    Service = item.Service,
                    Technology = item.Technology,
                    Office = item.Office,
                    College = item.College,
                    Address = item.Address
                });
            }

            return list;
        }

    }
}