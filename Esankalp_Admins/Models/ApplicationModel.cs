using Esankalp_Admins.Models;
using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;


namespace Esankalp_Admins.Models
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string CandidatePhoto { get; set; }
        public string ResumeFile { get; set; }
        public Nullable<System.DateTime> AppliedDate { get; set; }
        public string Status { get; set; }
        public string SaveApplication(ApplicationModel model)
        {
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();

            ApplicationMaster app =
                new ApplicationMaster();

            app.FullName = model.FullName;
            app.Email = model.Email;
            app.Mobile = model.Mobile;
            app.Position = model.Position;
            app.DOB = model.DOB;
            app.Gender = model.Gender;
            app.Skills = model.Skills;
            app.City = model.City;
            app.Address = model.Address;
            app.Education = model.Education;
            app.Experience = model.Experience;

            db.ApplicationMasters.Add(app);

            db.SaveChanges();

            return "Application Saved Successfully";
        }

        public List<ApplicationMaster> GetApplicationList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.ApplicationMasters.ToList();
        }
    }
}

    
