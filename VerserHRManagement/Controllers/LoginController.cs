using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VerserHRManagement.HelperServices;
using VerserHRManagement.Models;

namespace VerserHRManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            //"HRAdmin@verser.com.au" Verser2019!
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Session["FullUserName"] = null;
                Session["Accounts"] = null;
                Session["Administrator"] = null;
                Session["ErrorMessage"] = " Username Or Password Empty!";
                Session.Abandon();
                Session.Clear();                
                return View("Login");
            }
            LoginModel logindetails = new LoginModel { UserName = UserName, Password = Password };
            Task<LoginModel> userReturn = LoginService.Login(logindetails);
            if (userReturn.Result.IsLoggedIn == true)
            {
                Session["FullUserName"] = UserName;
                Session["FullName"] = userReturn.Result.FullName;
                Session["ErrorMessage"] = null;
                Session["Accounts"] = null;
                Session["Administrator"] = null;
                var _roles = LoginService.UserRoleList(UserName).Result;
                if (_roles.Count() > 0)
                {
                    foreach (var r in _roles)
                    {
                        if (r.Value == "Verser Admin" || r.Value == "Administrator")
                        {
                            Session["Administrator"] = "Administrator";
                        }
                        if (r.Value == "Accounts")
                        {
                            Session["Accounts"] = "Accounts";
                        }                        
                    }
                }
                return RedirectToAction("Index", "Candidates");
            }
            else
            {
                Session["FullUserName"] = null;
                Session["ErrorMessage"] = "Invalid UserName Or Password";
                return View("Login");
            }
        }
        public ActionResult Login()
        {
            Session["FullUserName"] = null;
            return View();
        }
    }
}