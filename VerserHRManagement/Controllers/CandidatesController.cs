using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerserHRManagement.HelperServices;
using VerserHRManagement.Models;
using VerserHRManagement.TimeSchedulerServices;

namespace VerserHRManagement
{
    public class CandidatesController : Controller
    {
        public ActionResult Index()
        {

            if (UserRoles.UserCanView() != true)
            {
                return RedirectToAction("Login", "Login");
            }

            Candidate model = new Candidate();
            model.CandidateList = CandidateService.CandidateList().Result;

            model.EmploymentList = new SelectList(ListItemService.EmploymentTypeList().Result, "ID", "Value");
            model.WarehouseNameList = new SelectList(ListItemService.Warehouses().Result, "ID", "Value");
            model.PayFrequencyList = new SelectList(ListItemService.PayFrequency().Result, "ID", "Value");
            
           
            model.AssignResourceList = new SelectList(ListItemService.AssignResources().Result, "ID", "Value");
            model.EmployeeStatusList = new SelectList(ListItemService.EmployeeStatusSet().Result, "ID", "Value");
            model.WorkRightsList = new SelectList(ListItemService.WorkRights().Result, "ID", "Value");
          
            return View(model);
        }
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
            {
                RedirectToAction("Login", "Login");
            }
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _candidate = CandidateService.FindCandidate(id).Result;
            _candidate.ID = id;
            return View(_candidate);
        }
        public ActionResult CreateNewProfile()
        {
            var model = new Candidate();
            model.EmploymentList = new SelectList(ListItemService.EmploymentTypeList().Result, "ID", "Value");
            model.WarehouseNameList = new SelectList(ListItemService.Warehouses().Result, "ID", "Value");
            model.PayFrequencyList = new SelectList(ListItemService.PayFrequency().Result, "ID", "Value");
            model.TechnicianLevelList = new SelectList(ListItemService.TechnicianLevel().Result, "ID", "Value");
            model.AssignResourceList = new SelectList(ListItemService.AssignResources().Result, "ID", "Value");
            model.EmployeeStatusList = new SelectList(ListItemService.EmployeeStatusSet().Result, "ID", "Value");
            model.WorkRightsList = new SelectList(ListItemService.WorkRights().Result, "ID", "Value");
            model.ResourceCategoriesList = new SelectList(ListItemService.ResourceCategories().Result, "ID", "Value");
            model.DrivingLicensesList = new SelectList(ListItemService.DrivingLicenses().Result, "ID", "Value");
            return View("Create",model);
        }
        [HttpPost]
        public ActionResult Create(Candidate candidate, string submitButton)
        {

            if (UserRoles.UserCanCreate() != true)
            {
                RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                
                string _filename;
                HttpPostedFileBase file = Request.Files["UploadResumeFile"];
                if (file.ContentLength > 0)
                {
                    _filename = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _filename);
                    file.SaveAs(_path);
                    candidate.FilePath = _filename;
                }
                candidate.DateCreated = DateTime.Now;
                candidate.isactive = true;
                CandidateService.Create(candidate);
                return View(candidate);               
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (UserRoles.UserCanEdit() == true)
            {
                if (id <= 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var candidate = CandidateService.FindCandidate(id).Result;
                if (candidate == null)
                {
                    return HttpNotFound();
                }
                return View(candidate);
            }
            else { return RedirectToAction("Index", "Candidates"); }

        }
        [HttpPost]

        public ActionResult Edit(Candidate candidate)
        {
            if (UserRoles.UserCanEdit() == true)
            {
                HttpPostedFileBase file = Request.Files["CVimgupload"];
                if (file.ContentLength > 0)
                {
                    var _filename = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _filename);
                    file.SaveAs(_path);
                    candidate.FilePath = _filename;
                }

                if (ModelState.IsValid)
                {
                    if (candidate.state == "NSW")
                    {
                        candidate.WarehouseID = 1;
                    }
                    else if (candidate.state == "VIC")
                    {
                        candidate.WarehouseID = 2;
                    }
                    else if (candidate.state == "QLD")
                    {
                        candidate.WarehouseID = 5;
                    }
                    else if (candidate.state == "ACT")
                    {
                        candidate.WarehouseID = 3;
                    }
                    else if (candidate.state == "WA")
                    {
                        candidate.WarehouseID = 4;
                    }
                    else if (candidate.state == "TAS")
                    {
                        candidate.WarehouseID = 6;
                    }

                    if (candidate.EmployementType.Contains("Permanent"))
                    {
                        candidate.EmployementTypeId = 1;
                    }
                    else if (candidate.EmployementType.Contains("Casual"))
                    {
                        candidate.EmployementTypeId = 2;
                    }
                    else if (candidate.EmployementType.Contains("Permanent Part-time"))
                    {
                        candidate.EmployementTypeId = 3;
                    }
                    CandidateService.Edit(candidate);
                    //db.Entry(candidate).State = EntityState.Modified;
                    //await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                return View(candidate);
            }
            else
            {
                return RedirectToAction("Index", "Candidates");
            }
        }
        [HttpPost]
        public ActionResult ExportTimesSheetToExcel()
        {
            //var candidateList = new List<CandidateExportModel>();

            var candidateList = new List<Candidate>();
            if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                candidateList = CandidateService.CandidateList().Result;
             
                GridView gv = new GridView();
                gv.DataSource = candidateList;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=ResourceList.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            return RedirectToAction("Index", "Candidates");
        }
        public ActionResult SMSBroadcast()
        {
            if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
            {
                RedirectToAction("Login", "Login");
            }
            return View(CandidateService.CandidateList().Result);
        }

        [HttpPost]
        public ActionResult UploadDocument()
        {
            var data = Request.Form["CandidateId"];
            var FolderPath = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"];
            if (FolderPath == null || FolderPath == "")
            {
                FolderPath = @"C:\VerserHRMS\Files\";
            }
            var fileType = Request.Form["FileUpload"];
            CandidateEdit theCandidate = new CandidateEdit();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                

                theCandidate.ID = int.Parse(data);
                if (fileType == "CVUpload")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Resume"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    theCandidate.FilePath = fileName;
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                }
                else if (fileType == "CertificateUpload")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Certificates"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.certificate1 = fileName;
                }
                else if (fileType == "DL")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["DL"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.DriverLicense = fileName;
                }
                else if (fileType == "PC")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["PC"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.PoliceCheckReport = fileName;
                }
                else if (fileType == "Visa")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Visa"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.Visa = fileName;
                }
                else if (fileType == "Super")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Super"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.SuperChoice = fileName;
                }
                else if (fileType == "TNF")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["TNF"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.TFNDeclaration = fileName;
                }
                else if (fileType == "Bank")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Bank"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.BankDetails = fileName;
                }
                else if (fileType == "Code")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Code"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.CodeOFConduct = fileName;
                }
                else if (fileType == "WHS")
                {
                    string path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["WHS"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName)); //File will be saved in application root
                    theCandidate.WHS = fileName;
                }
                //string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _filename);
            }
            CandidateService.EditCandidate(theCandidate);
            return RedirectToAction("Index");

            //theCandidate.ID = candidateId;


        }
        [HttpPost]
        public ActionResult UpdateCandidate(CandidateEdit candidate)
        {
            if (UserRoles.UserCanEdit() == true)
            {
                if (ModelState.IsValid)
                {

                    bool isupdated = CandidateService.EditCandidate(candidate);
                    if(isupdated)
                        return new JsonResult { Data = "The update has been successful.", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    else
                        return new JsonResult { Data = "The update is not successful.", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                return View(candidate);
            }
            else
            {
                return RedirectToAction("Index", "Candidates");
            }
        }
        public ActionResult DownloadFile(string textval)
        {
            try
            {
                var FolderPath = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"];
                string path = "";
                if (textval.Split(':')[0] == "certificate")
                {
                     path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Certificates"];
                }
                else if (textval.Split(':')[0] == "resume")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Resume"];
                }
                else if (textval.Split(':')[0] == "dl")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["DL"];
                }
                else if (textval.Split(':')[0] == "pc")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["PC"];
                }
                else if (textval.Split(':')[0] == "visa")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Visa"];
                }
                else if (textval.Split(':')[0] == "super")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Super"];
                }
                else if (textval.Split(':')[0] == "bank")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Bank"];
                }
                else if (textval.Split(':')[0] == "tnf")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["TNF"];
                }
                else if (textval.Split(':')[0] == "code")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["Code"];
                }
                else if (textval.Split(':')[0] == "whs")
                {
                    path = FolderPath + "\\" + System.Configuration.ConfigurationManager.AppSettings["WHS"];
                }

                if (textval == null || textval == "")
                {
                    return new JsonResult { Data = "There is no file present.", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                var data = Request.Form["Resume"];
                //string path = Path.Combine(Server.MapPath("~/UploadedFiles"), textval);
                byte[] fileBytes = System.IO.File.ReadAllBytes(path+"\\"+textval.Split(':')[1]);
                string fileName = textval;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public static void BulkMailEmail(List<CandidateListItems> ids,string subject,string body)
        {
            var mailmodel = new BulkMailModel();
            mailmodel.Subject = subject;
            mailmodel.Body = body;
            foreach (var c in ids)
            {
                var _candidate = CandidateService.CandidateList().Result.OrderBy(x => x.ID).ToList();             
             if (_candidate != null && _candidate.FirstOrDefault().Email != null)
                {
                    mailmodel.To = _candidate.FirstOrDefault().Email;
                  var _flagsign=  BulkEmailService.BulkMails(mailmodel).Result;
                }
            }
        }
    }
}
