using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class ResourceRatingModel
    {
        public int Id { get; set; }
        public int CandidateTimeSheetID { get; set; }
        public int Punctuality { get; set; }
        public int ProfessionalService { get; set; }
        public int PoliteAndCourteous { get; set; }        
        public int AverageRating { get; set; }
        public int WorkQuality { get; set; }       
        public int OneRating { get; set; }
        public int TwoRating { get; set; }
        public int ThreeRating { get; set; }
        public int FourRating { get; set; }
        public int FiveRating { get; set; }
        public int TotalRating { get; set; }
        public string User { get; set; }
        public string Comments { get; set; }
    }
}