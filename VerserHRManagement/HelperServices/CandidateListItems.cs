using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.HelperServices
{
    public class CandidateListItems
    {

        public int ID { get; set; }
        public string CandidateName { get; set; }
        public string CandidateSkills { get; set; }
        public Nullable<int> Phone { get; set; }
    }
}