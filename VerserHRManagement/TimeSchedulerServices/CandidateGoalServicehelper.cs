using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using VerserHRManagement.Models;

namespace VerserHRManagement.TimeSchedulerServices
{
    public class CandidateGoalServicehelper
    {
        private static readonly string TimeSheetAPIURl = ConfigurationManager.AppSettings["TimeSheetBaseURL"] + ConfigurationManager.AppSettings["TimeSheetRootDirectory"];

        public static bool AddResourcePerformanceGoals(ResourcePerformanceGoalsModel AddGoalModel)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.PostAsJsonAsync(string.Format("Resource/AddResourcePerformanceGoal"), AddGoalModel).Result;
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
    }
}