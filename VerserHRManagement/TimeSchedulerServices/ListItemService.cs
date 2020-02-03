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

        public static async Task<List<ListItemViewModel>> Warehouses()
        {
            List<ListItemViewModel> WarehousesList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/WarehouseList")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<WarehouseViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        WarehousesList.Add(new ListItemViewModel() { Id = w.Id, Value = w.WarehouseName });
                    }
                }
            }
            return WarehousesList;
        }
        public static async Task<List<ListItemViewModel>> PayFrequency()
        {
            List<ListItemViewModel> PayFrequencyList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/PayFrequencies")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<PayFrequencyViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        PayFrequencyList.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return PayFrequencyList;
        }
        public static async Task<List<ListItemViewModel>> TechnicianLevel()
        {
            List<ListItemViewModel> TechnicianLevelList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/TechnicalLevels")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<TechnicalLevels>>();

                    foreach (var w in Warehouses)
                    {
                        TechnicianLevelList.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return TechnicianLevelList;
        }

        public static async Task<List<ListItemViewModel>> EmployeeStatusSet()
        {
            List<ListItemViewModel> EmployeeStatusSetList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/EmployeeStatusSet")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<EmployeeStatusSetViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        EmployeeStatusSetList.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return EmployeeStatusSetList;
        }

        public static async Task<List<ListItemViewModel>> AssignResources()
        {
            List<ListItemViewModel> AssignResourcesList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/AssignResources")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<AssignResourceViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        AssignResourcesList.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return AssignResourcesList;
        }

        public static async Task<List<ListItemViewModel>> WorkRights()
        {
            List<ListItemViewModel> WorkRightsList = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<WorkRightsViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        WorkRightsList.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return WorkRightsList;
        }

        public static async Task<List<ListItemViewModel>> DrivingLicenses()
        {
            var DrivingLicenses = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/DrivingLicenses")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<AssignResourceViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        DrivingLicenses.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
            return DrivingLicenses;
        }

        public static async Task<List<ListItemViewModel>> ResourceCategories()
        {
           var ResourceCategories = new List<ListItemViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TimeSheetAPIURl);
                HttpResponseMessage response = client.GetAsync(string.Format("ListItems/ResourceCategories")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Warehouses = await response.Content.ReadAsAsync<List<AssignResourceViewModel>>();

                    foreach (var w in Warehouses)
                    {
                        ResourceCategories.Add(new ListItemViewModel() { Id = w.Id, Value = w.Value });
                    }
                }
            }
           return ResourceCategories;
        }
    }
    }
