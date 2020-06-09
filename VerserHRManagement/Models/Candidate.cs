using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using VerserHRManagement.Models;

namespace VerserHRManagement.Models
{
    public class Candidate
    {
        public Candidate()
        {
            ResourceReporting = new List<ListItemViewModel>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage = "CandidateName Field is Mandatory")]
        public string CandidateName { get; set; }
        [Required (ErrorMessage = "Skills Field is Mandatory")]
        [DataType(DataType.MultilineText)]
        public string CandidateSkills { get; set; }
        [Required(ErrorMessage = "Email Field is Mandatory")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Field is Mandatory")]
        public Nullable<int> Phone { get; set; }
        public string Address { get; set; }
        public string Experience { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string FilePath { get; set; }
        public string Annualsalary { get; set; }
        public string NoticePeriod { get; set; }
        [Required(ErrorMessage = "WorkRights Field is Mandatory")]
        public int? WorkRightID { get; set; }
        public string WorkRights { get; set; }       
        public SelectList WorkRightsList { get; set; }
        public string RecruiterComments { get; set; }
        [Required(ErrorMessage = "Postcode Field is Mandatory")]
        public string postcode { get; set; }
        public int? EmployeeStatusSetID { get; set; }
        public SelectList EmployeeStatusList { get; set; }
        public string EmployeeStatus { get; set; }
        [Required(ErrorMessage = "TechnicianLevel Field is Mandatory")]
        public int? technicalLevelsID { get; set; }
        public string TechnicianLevel { get; set; }       
        public SelectList TechnicianLevelList { get; set; }
        public string Availability { get; set; }
        [Required(ErrorMessage = "EmployementType Field is Mandatory")]
        public int? EmploymentTypesID { get; set; }
        public string EmployementType { get; set; }       
        public SelectList EmploymentList { get; set; }
        [Required(ErrorMessage = "HourlyRate Field is Mandatory")]
        public string HourlyRate { get; set; }
        public string DailyRate { get; set; }
        [Required(ErrorMessage = "State Field Is Mandatory")]
        public string state { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string RateOfSkillExperties { get; set; }
        [Required(ErrorMessage = "PayFrequency Field is Mandatory")]
        public int? PayFrequenciesID { get; set; }
        public string PayFrequency { get; set; }
        public SelectList PayFrequencyList { get; set; }        
        public SelectList AssignResourceList { get; set; }
        public int? AssignResourcesID { get; set; }
        public string AssignResource { get; set; }
        [Required(ErrorMessage = "ADP_EmployeeID Field is Mandatory")]
        public int ADP_EmployeeID { get; set; }
        [Required(ErrorMessage = "WarehouseID Field is Mandatory")]
        public int? WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public SelectList WarehouseNameList { get; set; }
        public int EmployementTypeId { get; set; }
        public bool isactive { get; set; }     
        public Byte[] profilePicture { get; set; } =new Byte[0];
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
        public SelectList ResourceCategoriesList { get; set; }
        public SelectList DrivingLicensesList { get; set; }
        public List<Candidate> CandidateList { get; set; }
        public ResourceRatingModel ResourceRating { get; set; }
        public int? ManagerID { get; set; }
        public string ReportingManager { get; set; }
        public bool isPeopleManager { get; set; }
        public List<ListItemViewModel> ResourceReporting { get; set; }
        public int? FK_ResourceInActiveReasonID { get; set; }
        public AllocatedAccessAndDevicesDto CandidateAllcaotedResouces { get; set; }
        public SelectList DirectReports { get; set; }
        public string InactiveReason { get; set; }
        public string fK_ResourceInActiveReasonID { get; set; }
        public SelectList CandidateNameList { get; set; }
        public List<int?> ResourceIDs { get; set; }
        public string[] ResourceReportees { get; set; }
        public string[] CurrentBirthdays { get; set; }
        public string Manager { get; set; }
    }

}
