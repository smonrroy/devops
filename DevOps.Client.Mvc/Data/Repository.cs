using DevOps.Client.Mvc.Entity;
using DevOps.Client.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOps.Client.Mvc.Data
{
    public class Repository
    {
        private readonly DevopsDBEntities _dbContext;
        public Repository()
        {
            _dbContext = new DevopsDBEntities();
        }

        public ServiceResponse getServices()
        {
            ServiceResponse oServiceResponse = new ServiceResponse();
            if (_dbContext != null)
            {
                try
                {
                    oServiceResponse.services = gettingServices();
                    oServiceResponse.success = true;
                    oServiceResponse.message = "consulta correcta";
                    return oServiceResponse;
                }
                catch (Exception e)
                {
                    oServiceResponse.success = false;
                    oServiceResponse.message = "Error: "+e.Message;
                    return oServiceResponse;
                }
                finally
                {
                    _dbContext.Dispose();
                }
            }
            else
            {
                oServiceResponse.success = false;
                oServiceResponse.message = "No se puede acceder a la base de datos, contactarse con el administrador.";
                return oServiceResponse;
            }
        }
        public ServiceResponse insertScore(FormEvaluationModel evaluation)
        {
            ServiceResponse oServiceResponse = new ServiceResponse();
            evaluation.Evaluation.evalDate = DateTime.Now;

            if (_dbContext != null)
            {
                try
                {
                    var evalDate = evaluation.Evaluation.evalDate.Date;
                    var existScoreDate = _dbContext.Evaluation.Any(x => x.idCustomer == evaluation.customer.idCustomer
                                                  && x.evalDate == evalDate
                                                  && x.idService == evaluation.Evaluation.idService);
                    if (existScoreDate)
                    {
                        oServiceResponse.success = false;
                        oServiceResponse.message = evaluation.customer.nameCustomer +
                                                    ", ud. ya realizó una evaluación del servicio el día de hoy "+
                                                    evaluation.Evaluation.evalDate.ToString("dd/MM/yyyy") +
                                                    ", puede volver a realizarlo el día de mañana ";
                        return oServiceResponse;
                    }
                    else
                    {
                        
                       if (!_dbContext.Customer.Any(x => x.idCustomer == evaluation.customer.idCustomer))
                        {
                            evaluation.customer.regDate = DateTime.Now;
                            var insCustomer=_dbContext.Customer.Add(evaluation.customer);
                            insCustomer.Evaluation.Add(evaluation.Evaluation);
                                _dbContext.SaveChanges();
                                oServiceResponse.services = gettingServices();
                                oServiceResponse.success = true;
                                oServiceResponse.message = "Evaluación registrada, gracias!.";
                                return oServiceResponse;
                        }
                        else
                        {
                            var customer = _dbContext.Customer.Find(evaluation.customer.idCustomer);
                            customer.Evaluation.Add(evaluation.Evaluation);
                            _dbContext.SaveChanges();
                            oServiceResponse.services = gettingServices();
                            oServiceResponse.success = true;
                            oServiceResponse.message = "Evaluación registrada, gracias!.";
                            return oServiceResponse;
                        }

                    }
                }
                catch (Exception e)
                {
                    oServiceResponse.success = false;
                    oServiceResponse.message = "Error: " + e.Message;
                    return oServiceResponse;
                }
                finally
                {
                    _dbContext.Dispose();
                }
            }
            else
            {
                oServiceResponse.success = false;
                oServiceResponse.message = "No se puede acceder a la base de datos, contactarse con el administrador.";
                return oServiceResponse;
            }
        }
        public ReportResponse getReporte(int idService)
        {
            ReportResponse oReportResponse = new ReportResponse();
            if (_dbContext != null)
            {
                try
                {
                    oReportResponse.reportEvaluation = (from eval in _dbContext.Evaluation
                                                        where eval.idService==idService
                                                        select new ReportEntity
                                                        {
                                                            idEval=eval.idEvaluation,
                                                            customer=eval.idCustomer+" : "+ eval.Customer.nameCustomer,
                                                            service=eval.Service.nameService,
                                                            detailService=eval.Service.serviceDetail,
                                                            score=eval.score,
                                                            evalDate=eval.evalDate,                                                            
                                                        }).ToList();
                    oReportResponse.success = true;
                    oReportResponse.message = "consulta correcta";
                    return oReportResponse;
                }
                catch (Exception e)
                {
                    oReportResponse.success = false;
                    oReportResponse.message = "Error: " + e.Message;
                    return oReportResponse;
                }
                finally
                {
                   _dbContext.Dispose();
                }
            }
            else
            {
                oReportResponse.success = false;
                oReportResponse.message = "No se puede acceder a la base de datos, contactarse con el administrador.";
                return oReportResponse;
            }
        }
        private List<Service> gettingServices()
        {
                try
                {
                var services = _dbContext.Service.Select(x => x).ToList();
                    return services;
                }
                catch (Exception e)
                {
                    return null;
                }
        }
    }
}