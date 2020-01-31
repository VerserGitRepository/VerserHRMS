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
    public class ListItemService
    {
        private static readonly string TimeSheetAPIURl = ConfigurationManager.AppSettings["TimeSheetBaseURL"] + ConfigurationManager.AppSettings["TimeSheetRootDirectory"];
        public static async Task<List<ListItemViewModel>> EmploymentTypeList()
        {
            List<ListItemViewModel> EmploymentList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("Resource/ResourceEmploymentType")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var projectactivities = await response.Content.ReadAsAsync<List<ListItemViewModel>>();

                    foreach (var a in projectactivities)
                    {
                        EmploymentList.Add(new ListItemViewModel() { Id = a.Id, Value = a.Value });
                    }
                }
            }
            return EmploymentList;
        }
    }
}