using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistrationList.Data;
using Esankalp_Admins.Models;
namespace Esankalp_Admins.Models
{
    public class ClientModel
    {
        public string ClientName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public string ProjectDetails { get; set; }

        public string SaveClient(ClientModel model)
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            ClientMaster cm =
                    new ClientMaster();

            cm.ClientName = model.ClientName;
            cm.CompanyName = model.CompanyName;
            cm.Email = model.Email;
            cm.Mobile = model.Mobile;
            cm.Address = model.Address;
            cm.ProjectDetails = model.ProjectDetails;
            cm.CreatedDate = DateTime.Now;
            db.ClientMasters.Add(cm);

            db.SaveChanges();

            return "Client Saved Successfully";
        }
        public List<ClientMaster> GetClientList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.ClientMasters.ToList();
        }
    }
}