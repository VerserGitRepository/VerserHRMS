using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerserHRManagement.Models
{

    public class CandidateEdit
    {
        public int ID { get; set; }

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
        public string RecruiterComments { get; set; }
        public int WorkRightID { get; set; }
        public string postcode { get; set; }
        public string EmployeeStatus { get; set; }

        public string TechnicianLevel { get; set; }
        public string Availability { get; set; }

        public string EmployementType { get; set; }

        public string HourlyRate { get; set; }
        public string DailyRate { get; set; }

        public string state { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string RateOfSkillExperties { get; set; }

        public string PayFrequency { get; set; }
        public string AssignResource { get; set; }

        public int ADP_EmployeeID { get; set; }
        public int WarehouseID { get; set; }
        public int EmploymentTypesID { get; set; }
        public bool isactive { get; set; }

        public Byte[] profilePicture { get; set; } = new Byte[0];
        public string certificate1 { get; set; }
        public string certificate2 { get; set; }
        public string certificate3 { get; set; }
        public string DriverLicense { get; set; }

        public string PoliceCheckReport { get; set; }
        public string Visa { get; set; }
        public string SuperChoice { get; set; }
        public string TFNDeclaration { get; set; }

        public string BankDetails { get; set; }
        public string CodeOFConduct { get; set; }
        public string WHS { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
        public int? ResourceCategoriesID { get; set; }
        public int? DrivingLicenseID { get; set; }
        public int AssignResourcesID { get; set; }
        public int technicalLevelsID { get; set; }
        public int EmployeeStatusSetID { get; set; }
        public int PayFrequenciesID { get; set; }
        public string InactiveReason { get; set; }
        public AllocatedAccessAndDevicesDto CandidateAllcaotedResouces { get; set; }

    }
}
