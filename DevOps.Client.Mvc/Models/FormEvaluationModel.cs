using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevOps.Client.Mvc.Data;

namespace DevOps.Client.Mvc.Models
{
    public class FormEvaluationModel
    {
        public List<Service> services   { get; set; }
        public Customer customer { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}