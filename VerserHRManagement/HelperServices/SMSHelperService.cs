using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace VerserHRManagement.HelperServices
{
    public class SMSHelperService
    {
        public static string SMSService(string message, string toDistList)
        {
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            string from = ConfigurationManager.AppSettings["from"].ToString();
            string baseurl = ConfigurationManager.AppSettings["baseurl"].ToString();
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("username", username);
            client.QueryString.Add("password", password);
            client.QueryString.Add("to", toDistList);
            client.QueryString.Add("from", from);
            client.QueryString.Add("message", message);
            client.QueryString.Add("ref", "123");
            client.QueryString.Add("maxsplit", "1");           
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return s;            
        }
    }
}