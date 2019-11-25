using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevOps.Client.Mvc;
using DevOps.Client.Mvc.Controllers;
using DevOps.Client.Mvc.Models;
using DevOps.Client.Mvc.Data;
using DevOps.Client.Mvc.Entity;

namespace DevOps.Client.Mvc.Integration.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            Repository oRepo = new Repository();
            ServiceResponse response = new ServiceResponse();

            // Act
            response = oRepo.getServices();

            // Assert
            Assert.AreEqual(true, response.success);
        }

        [TestMethod]
        public void Evaluate()
        {
            // Arrange
            FormEvaluationModel evaluation = new FormEvaluationModel
            {
                customer = new Customer(),
                Evaluation = new Evaluation()
            };
            evaluation.customer.idCustomer = "abcd@gm.net";
            evaluation.customer.nameCustomer = "Juan Perez";
            evaluation.customer.regDate = DateTime.Now;
            evaluation.Evaluation.idService = 1;
            evaluation.Evaluation.evalDate = DateTime.Now;
            evaluation.Evaluation.score = 8;
            //string msj = evaluation.customer.nameCustomer +
            //                                        ", ud. ya realizó una evaluación del servicio el día de hoy " +
            //                                        evaluation.Evaluation.evalDate.ToString("dd/MM/yyyy") +
            //                                        ", puede volver a realizarlo el día de mañana ";
            Repository oRepo = new Repository();
            ServiceResponse response = new ServiceResponse();

            // Act
            response = oRepo.insertScore(evaluation);

            // Assert

                Assert.AreEqual(false, response.success);
       

            
        }

        [TestMethod]
        public void getReport()
        {
            // Arrange
            Repository oRepo = new Repository();
            ReportResponse response = new ReportResponse();
            int idService = 2;
            // Act
            response = oRepo.getReporte(idService);

            // Assert
            Assert.AreEqual(true,response.success);
        }

        [TestMethod]
        public void Report()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Report() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
