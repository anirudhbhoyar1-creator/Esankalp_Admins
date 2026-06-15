using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esankalp_Admins.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string mob { get; set; }
        public string msg { get; set; }

        public List<contact> GetContactList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.contacts.ToList();
        }
      
    }
}