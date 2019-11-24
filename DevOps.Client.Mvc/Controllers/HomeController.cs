using DevOps.Client.Mvc.Data;
using DevOps.Client.Mvc.Entity;
using DevOps.Client.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOps.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FormEvaluationModel oModel = new FormEvaluationModel();
            Repository oRepo = new Repository();
            var response = oRepo.getServices();
            if (response.success)
            {
                oModel.services = response.services;
                return View(oModel);
            }
            else
            {
                return Json(new { msj = response.message },JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Evaluate(FormEvaluationModel evaluation)
        {
            Repository oRepo = new Repository();
            var response = oRepo.insertScore(evaluation);
            if (response.success)
            {
                FormEvaluationModel oModel = new FormEvaluationModel();
                oModel.services = response.services;
                return PartialView("Index",oModel);
            }
            else
            {
                return Json(new { msj = response.message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult getReport(int idService)
        {
            Repository oRepo = new Repository();
            var response = oRepo.getReporte(idService);
            if (response.success)
            {
                ReportModel oModel = new ReportModel();
                oModel.evaluations = response.reportEvaluation;
                return PartialView("_DetailReport", oModel.evaluations);
            }
            else
            {
                return Json(new { msj = response.message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Report()
        {
            Repository oRepo = new Repository();
            var response = oRepo.getServices();
            if (response.success)
            {
                ReportModel oModel = new ReportModel();
                oModel.evaluations= new List<ReportEntity>();
                oModel.services = response.services;
                return View(oModel);
            }
            else
            {
                return Json(new { msj = response.message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}