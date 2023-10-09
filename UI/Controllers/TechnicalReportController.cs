using Connecter.Client;
using Connecter.Models;
using Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using ServiceReference;
using UI.Repositries;

namespace UI.Controllers
{
    public class TechnicalReportController : Controller
    {
        readonly private IClientContainer _Client;
        IClientComplaintType _complaintType;
        private readonly IClientLookup _ClientLookup;
        private readonly IRepositoryGeneralRequest _request;
        private readonly IRepositoryActionHistory _ActionsHistory;
        private readonly TaskActionSoapClient _K2Service;

        private readonly MyDbContext _dbContext;
        public TechnicalReportController(IClientContainer Client, IClientLookup ClientLookup, IClientComplaintType complaintType, IRepositoryGeneralRequest request, IRepositoryActionHistory ActionsHistory, TaskActionSoapClient K2Service, MyDbContext dbContext)
        {
            _Client = Client;
            _ClientLookup = ClientLookup;
            _complaintType = complaintType;
            _request = request;
            _ActionsHistory = ActionsHistory;
            _K2Service = K2Service;

            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int id)
        {
            var Employee = await _Client.Employee.GetByID(1);
            ViewBag.EmpName = Employee.NameArabic;

            var Dept = await _Client.Lookup.GetByID(3);
            ViewBag.EmpDept = Dept.NameArabic;

            var EmpBranch = await _ClientLookup.GetDept(Convert.ToInt32(Employee.DepartmentId));
            ViewBag.EmpBranch = EmpBranch;

            return View();
        }
        public async Task<ActionResult> Save(DTO.TechnicalReport technicalReport)
        {
            Response forcast23;
            if (technicalReport.Id == 0)
            {
                forcast23 = await _Client.TechnicalReport.Insert(technicalReport);
                technicalReport = JsonConvert.DeserializeObject<DTO.TechnicalReport>(forcast23.Result.ToString());

                //#region GeneralRequests
                //Entity.GeneralRequest generalRequest = await _request.InsertGeneralRequest(technicalReport.Id, (int)UI.Classes.ServiceTypes.Complaint, (int)UI.Classes.Steps.Technical_Report);
                //#endregion

                //#region ActionHistory
                //Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                //#endregion
                //var EmpName = "Q.abed";


                //ServiceReference.StartProcessResponse Response = await _K2Service.StartProcessAsync(EmpName, technicalReport.Id, generalRequest.RequestId, UI.Classes.Constants.ProcessIEC_Complaint);
                //int ProcessID = int.Parse(Response.Body.StartProcessResult.ToString());
                //generalRequest.ProcessId = ProcessID;
                //_dbContext.SaveChanges();

            }
            else
            {
                forcast23 = await _Client.TechnicalReport.Update(technicalReport);
            }
            if (forcast23.IsSuccess)
            {
                if (forcast23 != null)
                {
                    return RedirectToAction("Index", "complaint");
                }
            }
            else
            {
                return View("Index", technicalReport.Id);
            }
            return View();
        }
    }
}
