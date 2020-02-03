using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VerserHRManagement.Models;

namespace VerserHRManagement.HelperServices
{
    public class BulkEmailService
    {
        public async static Task<bool> BulkMails(BulkMailModel emails)
        {
            bool returnmessage = false;
            string BaseUri = ConfigurationManager.AppSettings["AMSBase"] + ConfigurationManager.AppSettings["AMSRoot"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                HttpResponseMessage response = client.PostAsJsonAsync("EmailService/SendBulkMail", emails).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    returnmessage = result;
                }
            }
            return returnmessage;
        }
    }
}