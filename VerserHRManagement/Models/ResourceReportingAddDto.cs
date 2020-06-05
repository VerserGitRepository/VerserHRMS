using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class ResourceReportingAddDto
    {
        public List<int> ResourceReportings_ResourceIds { get; set; }
        public int ResourceReporting_ManagerId { get; set; }
    }
}