using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using VerserHRManagement.Models;
using VerserHRManagement.TimeSchedulerServices;
using VerserHRManagement.HelperServices;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;

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
            return View(CandidateService.CandidateList().Result);
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

        public ActionResult Create()
        {
            return View();
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

                //db.Candidate.Add(candidate);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        public ActionResult Edit(int id)
        {
            if (UserRoles.UserCanEdit() == true)
            //if (Session["UserName"] != null && Session["Administrator"] != null)
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
        // [ValidateAntiForgeryToken]
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

        //public ActionResult Delete(int id)
        //{
        //    if (string.IsNullOrEmpty(Session["FullUserName"].ToString()))
        //    {
        //        return RedirectToAction("Login", "Login");
        //    }
        //    else
        //    {
        //        if (id <= 0)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        var candidate = CandidateService.FindCandidate(id).Result;
        //        if (candidate == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(candidate);
        //    }
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var candidate = CandidateService.DeleteHRMSCandidate(id);
            //Candidate candidate = await db.Candidate.FindAsync(id);
            //db.Candidate.Remove(candidate);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ExportTimesSheetToExcel()
        {
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


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult UploadDocument(int candidateId)
        {
            Candidate theCandidate = new Candidate();
            theCandidate.ID = candidateId;
            if (UserRoles.UserCanEdit() == true)
            {

                if (Request.Files["CVimgupload"].ContentLength > 0)
                {
                    var _filename = Path.GetFileName(Request.Files["CVimgupload"].FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _filename);
                    Request.Files["CVimgupload"].SaveAs(_path);
                    theCandidate.FilePath = _filename;
                }
            }
            return null;
        }
    }
}
