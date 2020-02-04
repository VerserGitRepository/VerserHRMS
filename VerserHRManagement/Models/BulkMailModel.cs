using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class BulkMailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}