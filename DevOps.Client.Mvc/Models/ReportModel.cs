using DevOps.Client.Mvc.Data;
using DevOps.Client.Mvc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOps.Client.Mvc.Models
{
    public class ReportModel
    {
        public List<ReportEntity> evaluations { get; set; }
        public List<Service> services { get; set; }
    }
}