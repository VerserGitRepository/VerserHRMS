﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace VerserHRManagement.Models
{

    public class Candidate
    {
        public int ID { get; set; }
        [Required]
        public string CandidateName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string CandidateSkills { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[MaxLength(10)]
        //[MinLength(6)]
        public Nullable<int> Phone { get; set; }
        public string Address { get; set; }
        public string Experience { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string FilePath { get; set; }
        public string Annualsalary { get; set; }
        public string NoticePeriod { get; set; }
        [Required]
        public string WorkRights { get; set; }
        public int? WorkRightsID { get; set; }
        public SelectList WorkRightsList { get; set; }
        public string RecruiterComments { get; set; }
        [Required]
        //[MaxLength(4)]
        //[MinLength(3)]
        public string postcode { get; set; }
        public int? EmployeeStatusSetID { get; set; }
        public SelectList EmployeeStatusList { get; set; }
        public string EmployeeStatus { get; set; }
        [Required]
        public string TechnicianLevel { get; set; }
        public int? TechnicianLevelID { get; set; }
        public SelectList TechnicianLevelList { get; set; }
        public string Availability { get; set; }
        [Required]
        public string EmployementType { get; set; }
        public int? EmploymentTypesID { get; set; }
        public SelectList EmploymentList { get; set; }
        [Required]
        public string HourlyRate { get; set; }
        public string DailyRate { get; set; }
        [Required]
        public string state { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string RateOfSkillExperties { get; set; }
        [Required]
        public string PayFrequency { get; set; }
        public SelectList PayFrequencyList { get; set; }
        public int? PayFrequenciesID { get; set; }
        public SelectList AssignResourceList { get; set; }
        public int? AssignResourcesID { get; set; }
        public string AssignResource { get; set; }
        [Required]
        public int ADP_EmployeeID { get; set; }
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
        public int? WorkRightID { get; set; }
    }
}
