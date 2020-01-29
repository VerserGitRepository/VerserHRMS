using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VerserHRManagement.Models;

namespace VerserHRManagement.TimeSchedulerServices
{
    public class CandidateService
    {
        private static readonly string TimeSheetAPIURl = ConfigurationManager.AppSettings["TimeSheetBaseURL"] + ConfigurationManager.AppSettings["TimeSheetRootDirectory"];

        public static async Task<List<Candidate>> CandidateList()
        {
            List<Candidate> CandidatList = new List<Candidate>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("Resource/HRMSCandidateList")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var _Candidates = await response.Content.ReadAsAsync<List<Candidate>>();

                    foreach (var c in _Candidates)
                    {
                        CandidatList.Add(c);
                    }
                }
            }
            return CandidatList;
        }
        public static async Task<Candidate> FindCandidate(int candidateid)
        {
           var CandidatDetail = new Candidate();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("Resource/FindHRMSCandidate/{0}", candidateid)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var _candidate = await response.Content.ReadAsAsync<Candidate>();
                    if (_candidate != null)
                    {
                        CandidatDetail = _candidate;

                        //CandidatDetail = new Candidate
                        //{
                        //    CandidateName = _candidate.CandidateName,
                        //    CandidateSkills = _candidate.CandidateSkills,
                        //    Email = _candidate.Email,
                        //    Phone = _candidate.Phone,
                        //    Address = _candidate.Address,
                        //    Experience = _candidate.Experience,
                        //    City = _candidate.City,
                        //    JobTitle = _candidate.JobTitle,
                        //    FilePath = _candidate.FilePath,
                        //    Annualsalary = _candidate.Annualsalary,
                        //    NoticePeriod = _candidate.NoticePeriod,
                        //    WorkRights = _candidate.WorkRights,
                        //    RecruiterComments = _candidate.RecruiterComments,
                        //    postcode = _candidate.postcode,
                        //    EmployeeStatus = _candidate.EmployeeStatus,
                        //    EmployementType=_candidate.EmployementType,
                        //    TechnicianLevel = _candidate.TechnicianLevel,
                        //    Availability = _candidate.Availability,
                        //    HourlyRate = _candidate.HourlyRate,
                        //    DailyRate = _candidate.DailyRate,
                        //    state = _candidate.state,
                        //    PayFrequency=_candidate.PayFrequency,
                        //    DateCreated = _candidate.DateCreated,
                        //    ADP_EmployeeID=_candidate.ADP_EmployeeID,                           
                        //    AssignResource =_candidate.AssignResource,                           
                        //    RateOfSkillExperties = _candidate.RateOfSkillExperties
                        //    //EmployementTypeId = _candidate.EmployementTypeId,
                        //    //WarehouseID = _candidate.WarehouseID
                        //};
                    }

                }
            }
            return CandidatDetail;
        }
        public static async Task<bool> DeleteHRMSCandidate(int candidateid)
        {
            bool returnflag = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("Resource/DeleteHRMSCandidate/{0}", candidateid)).Result;
                if (response.IsSuccessStatusCode)
                {
                    returnflag = await response.Content.ReadAsAsync<bool>();                   
                }
            }
            return returnflag;
        }

        public static bool Create(Candidate CandidateModel)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.PostAsJsonAsync(string.Format("Resource/HRMSResourceCreate"), CandidateModel).Result;
                if (response.IsSuccessStatusCode)
                {
                   // ReturnResult = await response.Content.ReadAsAsync<ReturnModel>();
                  //  HttpContext.Current.Session["ResultMessage"] = ReturnResult.Message;
                    return true;
                }
                else
                {
                   // HttpContext.Current.Session["ErrorMessage"] = ReturnResult.Message;
                }
            }
            return false;
        }
        public static bool Edit(Candidate CandidateModel)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.PostAsJsonAsync(string.Format("Resource/HRMSResourceEdit"), CandidateModel).Result;
                if (response.IsSuccessStatusCode)
                {
                    // ReturnResult = await response.Content.ReadAsAsync<ReturnModel>();
                    //  HttpContext.Current.Session["ResultMessage"] = ReturnResult.Message;
                    return true;
                }
                else
                {
                    // HttpContext.Current.Session["ErrorMessage"] = ReturnResult.Message;
                }
            }
            return false;
        }
        public static bool EditCandidate(CandidateEdit CandidateModel)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.PostAsJsonAsync(string.Format("Resource/HRMSResourceEdit"), CandidateModel).Result;
                if (response.IsSuccessStatusCode)
                {

                    HttpContext.Current.Session["SuccessMessage"] = "Changes Updated Successfully !";
                    return true;
                }
                else
                {
                    HttpContext.Current.Session["ErrorMessage"] = "Unable To Update The Changes Please validate !";
                }
            }
            return false;
        }
    }
}