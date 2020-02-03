using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class CandidateExportModel
    {
        public string CandidateName { get; set; }
        public string CandidateSkills { get; set; }
        public string Email { get; set; }    
        public Nullable<int> Phone { get; set; }
        public string Address { get; set; }
        public string Experience { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string FilePath { get; set; }
        public string Annualsalary { get; set; }
        public string NoticePeriod { get; set; }   
        public string WorkRights { get; set; }
        public int? WorkRightsID { get; set; }     
        public string RecruiterComments { get; set; } 
        public string postcode { get; set; }
        public string EmployeeStatus { get; set; }     
        public string TechnicianLevel { get; set; }  
        public string Availability { get; set; }     
        public string EmployementType { get; set; }    
        public string HourlyRate { get; set; }
        public string DailyRate { get; set; } 
        public string state { get; set; }
       
        public string RateOfSkillExperties { get; set; }
        public string PayFrequency { get; set; }             
        public string AssignResource { get; set; }  
        public int ADP_EmployeeID { get; set; }  
        public string WarehouseName { get; set; }  
        public bool isactive { get; set; }
       
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
    }
}