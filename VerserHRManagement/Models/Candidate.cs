﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerserHRManagement.Models
{

    public class Candidate
    {
        public int ID { get; set; }
        [Required]
        public string CandidateName { get; set; }
        [Required]
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
        public string RecruiterComments { get; set; }
        [Required]
        //[MaxLength(4)]
        //[MinLength(3)]
        public string postcode { get; set; }
        public string EmployeeStatus { get; set; }
        [Required]
        public string TechnicianLevel { get; set; }
        public string Availability { get; set; }
        [Required]
        public string EmployementType { get; set; }
        [Required]
        public string HourlyRate { get; set; }
        public string DailyRate { get; set; }
        [Required]
        public string state { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string RateOfSkillExperties { get; set; }
        [Required]
        public string PayFrequency { get; set; }
        public string AssignResource { get; set; }
        [Required]
        public int ADP_EmployeeID { get; set; }
        public int WarehouseID { get; set; }
        public int EmployementTypeId { get; set; }
        public bool isactive { get; set; }
        public byte[] ProfilePic { get; set; } = new byte[0];
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
    }
}
