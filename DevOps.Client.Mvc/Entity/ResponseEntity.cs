using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevOps.Client.Mvc.Data;

namespace DevOps.Client.Mvc.Entity
{
    public class ResponseEntity
    {
        public string message { get; set; }
        public bool success { get; set; }
    }

    public class ServiceResponse:ResponseEntity
    {
        public List<Service> services { get; set; }
    }

    public class ReportEntity
    {
        public string customer { get; set; }
        public string service { get; set; }
        public string detailService { get; set; }
        public int score { get; set; }
        public DateTime evalDate { get; set; }
        public int idEval { get; set; }
    }

    public class ReportResponse : ResponseEntity
    {
        public List<ReportEntity> reportEvaluation { get; set; }
    }

}