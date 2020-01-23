using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using VerserHRManagement.HelperServices;
using VerserHRManagement.Models;

namespace VerserHRManagement.Controllers
{
    public class MultiSelectDropDownController : Controller
    {
        // GET: MultiSelectDropDown
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {

                MultiSelectDropDownViewModel model = new MultiSelectDropDownViewModel
                {
                    SelectedMultiCandidateId = new List<int>(),
                    CandidateList = new List<CandidateListItems>()
                };

                try
                {
                    // Loading drop down lists.  
                    // model.CandidateList = CandidatesListExport.ResourceList();
                    this.ViewBag.CountryList = this.GetCandidateList();
                }
                catch (Exception ex)
                {
                    // Info  
                    Console.Write(ex);
                }

                // Info.  
                return this.View(model);
            }

        }

        private List<CandidateListItems> LoadData()
        {
            // Initialization.  
            List<CandidateListItems> lst = new List<CandidateListItems>();

            try
            {

                lst= CandidatesListExport.ResourceList();
                //// Initialization.  
                //string line = string.Empty;
                //string rootFolderPath = this.Server.MapPath("~/Content/");
                //string fileName = "country_list.txt";
                //string fullPath = rootFolderPath + fileName;
                //string srcFilePath = new Uri(fullPath).LocalPath;
                //StreamReader sr = new StreamReader(new FileStream(srcFilePath, FileMode.Open, FileAccess.Read));

                //// Read file.  
                //while ((line = sr.ReadLine()) != null)
                //{
                //    // Initialization.  
                //    CandidateListItems infoObj = new CandidateListItems();
                //    string[] info = line.Split(',');

                //    // Setting.  
                //    infoObj.ID = Convert.ToInt32(info[0].ToString());
                //    infoObj.CandidateName = info[1].ToString();

                //    // Adding.  
                //    lst.Add(infoObj);
                //}

                // Closing.  
                //sr.Dispose();
                //sr.Close();
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }


        #region Get country method.  

        /// <summary>  
        /// Get country method.  
        /// </summary>  
        /// <returns>Return country for drop down list.</returns>  
        private IEnumerable<SelectListItem> GetCandidateList()
        {
            // Initialization.  
            SelectList lstobj = null;

            try
            {
                // Loading.  
                var list = this.LoadData()
                                  .Select(p =>
                                            new SelectListItem
                                            {
                                                Value = p.ID.ToString(),
                                                Text = p.CandidateName
                                            });

                // Setting.  
                lstobj = new SelectList(list, "Value", "Text");
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // info.  
            return lstobj;
        }

        /// <summary>  
        /// POST: /MultiSelectDropDown/Index  
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <returns>Return - Response information</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MultiSelectDropDownViewModel model)
        {
            // Initialization.  
            string filePath = string.Empty;
            string fileContentType = string.Empty;

            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    List<CandidateListItems> candidateList = this.LoadData();
                    
                    model.CandidateList = candidateList.Where(p => model.SelectedMultiCandidateId.Contains(p.ID)).Select(q => q).ToList();

                    List<string> ToDistlist = CandidatesListExport.ResourceNumber(model.CandidateList);
                    string AppendedPhoneList = string.Join(",", ToDistlist.Where(m => !string.IsNullOrEmpty(m)).ToList());

                   string r = SMSHelperService.SMSService(model.MessageText, AppendedPhoneList);
                    if (r !=null)
                    {
                        r = "SMS Sent To Select Receipnts Sucessfully  " + r;
                    }
                    Session["ResultMessage"] = r;
                }

                // Loading drop down lists.  
                this.ViewBag.CountryList = this.GetCandidateList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info  
            return this.View(model);
        }

        #endregion

    }
}