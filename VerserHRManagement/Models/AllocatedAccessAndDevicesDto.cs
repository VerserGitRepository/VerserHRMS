using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class AllocatedAccessAndDevicesDto
    {
		public int ID { get; set; }
		public int FK_CandidateId { get; set; }
		public bool DESKSETUP { get; set; }
		public bool LAPTOPSETUP { get; set; }
		public bool OFFICEMOBILE { get; set; }
		public bool OFFICEIPAD { get; set; }
		public bool MONITORS { get; set; }
		public bool JMSUSERACCOUNT { get; set; }
		public bool O365ACCOUNT { get; set; }
		public bool WHSACCOUNT { get; set; }
		public bool DOMAINACCOUNT { get; set; }
		public bool SHAREPOINTACCESS { get; set; }
		public bool ADPREGISTER { get; set; }
		public bool SALARYACCOUNT { get; set; }
		public bool TFSACCOUNT { get; set; }
		public bool SUPERACCOUNT { get; set; }
	}
}