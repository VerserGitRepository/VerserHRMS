using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VerserHRManagement.Models;
using VerserHRManagement.TimeSchedulerServices;

namespace VerserHRManagement.HelperServices
{
    public class CandidatesListExport
    {

        public static List<Candidate> Resources()
        {
            //if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
            //{
            //    RedirectToAction("Login", "Login");
            //}
            
            List<Candidate> CandidateLists = new List<Candidate>();
            var Candidates = CandidateService.CandidateList().Result.OrderBy(x=>x.ID).ToList();
            CandidateLists = Candidates;
            return CandidateLists;
        }

        public static List<CandidateListItems> ResourceList()
        {
          
            List<CandidateListItems> CandidateLists = new List<CandidateListItems>();
            var Candidates = CandidateService.CandidateList().Result.OrderBy(x => x.ID).ToList();
            //   CandidateLists = Candidates;

            foreach (var c in Candidates)
            {
                CandidateLists.Add(new CandidateListItems() { ID = c.ID, CandidateName = c.CandidateName });
            }
            return CandidateLists;
        }

        public static List<string> ResourceNumber(List<CandidateListItems> candidateList)
        {
           var CandidateNoList = new List<string>();
            foreach (var c in candidateList)
            {
                var PhoneNo = CandidateService.CandidateList().Result.OrderBy(x => x.ID).ToList();
                PhoneNo.Where(n=>n.ID==c.ID);
                if (PhoneNo != null)
                {
                    string phone =  PhoneNo.FirstOrDefault().Phone.ToString();                
                    CandidateNoList.Add($"+61 {phone}");
                }
            }
            return CandidateNoList;
        }       
    }
}

