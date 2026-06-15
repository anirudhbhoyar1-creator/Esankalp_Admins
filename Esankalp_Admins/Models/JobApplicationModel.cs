using RegistrationList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esankalp_Admins.Models;
namespace Esankalp_Admins.Models
{
    public class JobApplicationModel
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PositionAppliedFor { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> InterviewDate { get; set; }
        public string ResumePath { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string SaveJobApplication(JobApplicationModel model)
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            JobApplicationMaster jm =
                new JobApplicationMaster();

            jm.CandidateName = model.CandidateName;
            jm.Email = model.Email;
            jm.Mobile = model.Mobile;
            jm.PositionAppliedFor = model.PositionAppliedFor;
            jm.Status = model.Status;
            jm.InterviewDate = model.InterviewDate;
            jm.ResumePath = model.ResumePath;

            db.JobApplicationMasters.Add(jm);

            db.SaveChanges();

            return "Job Application Saved Successfully";
        }

        public List<JobApplicationMaster> GetJobApplicationList()
        {
            esankal1_esankalpEntities db =
                new esankal1_esankalpEntities();

            return db.JobApplicationMasters.ToList();
        }
    }
}
    