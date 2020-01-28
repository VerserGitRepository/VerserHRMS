using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerserHRManagement.HelperServices;

namespace VerserHRManagement.Models
{
    public class MultiSelectDropDownViewModel
    {
        [Required]
        [Display(Name = "Choose Multiple Candidates")]
        public List<int> SelectedMultiCandidateId { get; set; }
        public int CandidateId{ get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }
                                           /// <summary>  
                                           /// Gets or sets selected countries property.  
                                           /// </summary>  
        public List<CandidateListItems> CandidateList { get; set; }

        public string ReturnMessage { get; set; }
        public SelectList CandidatesList { get; set; }

        // public SelectList CandidateList { get; set; }

    }
}