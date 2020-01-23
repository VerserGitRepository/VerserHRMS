using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VerserHRManagement.TimeSchedulerDBEntities
{
    public class TimesheetDBEntities :DbContext
    {
        public TimesheetDBEntities() : base("name=TimeSchedulerEntities") { }
        public virtual DbSet<Candidate> Candidate { get; set; }
    }
}