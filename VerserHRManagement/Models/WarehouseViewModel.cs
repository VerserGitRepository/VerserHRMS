using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerserHRManagement.Models
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public int CostCentreID { get; set; }
        public string WarehouseNo { get; set; }

    }
}