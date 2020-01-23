using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.HelperServices
{
    public class UserRoles
    {
        public static bool UserCanCreate()
        {
            if (HttpContext.Current.Session["Username"] != null)
            {
                if (HttpContext.Current.Session["Accounts"] != null ||  HttpContext.Current.Session["ProjectManager"] != null || HttpContext.Current.Session["Administrator"] != null)
                {
                    return true;
                }
            }
            return false;
        }
       
        public static bool UserCanEdit()
        {
            bool Returnflag = false;
            if (HttpContext.Current.Session["FullUserName"] != null)
            {
                if (HttpContext.Current.Session["Accounts"] !=null && HttpContext.Current.Session["Accounts"].ToString() == "Accounts")                     
                {
                    Returnflag= true;
                }
                else if (HttpContext.Current.Session["Administrator"] !=null && HttpContext.Current.Session["Administrator"].ToString() == "Administrator")
                {
                    Returnflag = true;
                }
                else if (HttpContext.Current.Session["HRAdmin"] != null && HttpContext.Current.Session["HRAdmin"].ToString() == "HRAdmin")
                {
                    Returnflag = true;
                }
            }
            return Returnflag;
        }

        public static bool UserCanView()
        {
            if (HttpContext.Current.Session["FullUserName"] != null)
            {
                    return true;               
            }
            return false;
        }
    }
}
