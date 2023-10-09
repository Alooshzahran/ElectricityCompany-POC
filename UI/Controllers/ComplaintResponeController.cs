using Connecter.Client;
using Connecter.Models;
using DTO;
using Entity;
using Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using Repository;
using ServiceReference;
using System;
using System.Threading.Tasks.Dataflow;
using UI.Repositries;

namespace UI.Controllers
{
    public class ComplaintResponeController : Controller
    {
        readonly private IClientContainer _Client;
        IClientComplaintType _complaintType;
        private readonly IClientLookup _ClientLookup;
        private readonly IRepositoryGeneralRequest _request;
        private readonly IRepositoryActionHistory _ActionsHistory;
        private readonly TaskActionSoapClient _K2Service;
        private readonly IUnitofwork _unitofwork;
        private readonly MyDbContext _dbContext;
        public ComplaintResponeController(IClientContainer Client, IClientLookup ClientLookup, IClientComplaintType complaintType, IRepositoryGeneralRequest request, IRepositoryActionHistory ActionsHistory, TaskActionSoapClient K2Service, IUnitofwork unitofwork, MyDbContext dbContext)
        {
            _Client = Client;
            _ClientLookup = ClientLookup;
            _complaintType = complaintType;
            _request = request;
            _ActionsHistory = ActionsHistory;
            _K2Service = K2Service;
            _unitofwork = unitofwork;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> ResponseToComplaint()
        {
            int complaintid = Convert.ToInt32(Request.Cookies["ComplaintId"]);
            var actionBack = Request.Query["stepId"];
            if (actionBack != "")
            {
                ViewBag.ActionBack = actionBack;
            }
            else
            {
                ViewBag.ActionBack = "";
            }
            string serialNo = HttpContext.Request.Query["serialNo"].ToString();
            ViewBag.serialNo = serialNo;
           
          
            
            
            var Employee = await _Client.Employee.GetByID(1);
            ViewBag.EmpName = Employee.NameArabic;

            var Dept = await _Client.Lookup.GetByID(3);
            ViewBag.EmpDept = Dept.NameArabic;

            var EmpBranch = await _ClientLookup.GetDept(Convert.ToInt32(Employee.DepartmentId));
            ViewBag.EmpBranch = EmpBranch;

            DTO.Complaint complaint = await _Client.Complaint.GetByID(complaintid);
            if (complaint != null)
            {
                ViewBag.person = complaint.CallerName;
            }
            if(complaint.ComplaintNo != null)
            {
                ViewBag.ComplaintNo = complaint.ComplaintNo;
            }
            else
            {
                ViewBag.ComplaintNo ="";
            }
            
            if(complaint.Phone != null)
            {
                ViewBag.Phone = complaint.Phone;
            }
            else { ViewBag.Phone = "0"; }

            if (complaint.Fax != null)
            {
                ViewBag.Fax = complaint.Fax;
            }
            else { ViewBag.Fax = "0"; }

            if (complaint.Mobile != null)
            {
                ViewBag.Mobile = complaint.Mobile;
            }
            else { ViewBag.Mobile = "0"; }

            ViewBag.Date = complaint.MalfunctionDate;

            DTO.Lookup Method =await _Client.Lookup.GetByID(Convert.ToInt32(complaint.ComplaintMethodId));
            ViewBag.ComplaintMethod = Method.NameArabic;

            ViewBag.Address = complaint.Address;

            var AllEmployee = await _Client.Employee.GetAll();
            ViewBag.AllEmployee= new SelectList(AllEmployee, "Id", "NameArabic");

            var AllComplaintStatus = await _ClientLookup.GetAllComplaintStatus();
            ViewBag.AllComplaintStatus = new SelectList(AllComplaintStatus, "Id", "NameArabic");

            var AllExportoffice  = await _ClientLookup.GetAllExportoffice();
            ViewBag.AllExportoffice = new SelectList(AllExportoffice, "Id", "NameArabic");

            //var complaintResponse = new ComplaintResponse();
            var requsets = _request.GetAll();
            int stepId = Convert.ToInt32(requsets.FirstOrDefault(e => e.RequestId == complaint.RequestId).StepId);
            if (stepId == 1)
            {
                ViewBag.ShowstepId = "";
            }
            else if(stepId == 2) 
            {
                ViewBag.ShowstepId = "block";
            }
            else
            {
                ViewBag.ShowstepId = "";
                var allcomplaintres = await _Client.ComplaintResponse.GetAll();
                var complaintres = allcomplaintres.FirstOrDefault(e =>e.RequestId == complaint.RequestId);
                return View(complaintres);
            }

            return View();
        }

        public async Task<ActionResult> Save(DTO.ComplaintResponse complaintResponse )
        {

            var EmpName = "Q.Abed";
           
            var complaintid = Convert.ToInt32(Request.Cookies["complaintid"]);
            DTO.Complaint complaint = await _Client.Complaint.GetByID(complaintid);
            GetEmployeeTaskListResponse result1 = await _K2Service.GetEmployeeTaskListAsync(EmpName, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result1.Body.GetEmployeeTaskListResult;
            K2TaskItem taskitem = Items.Where(e => e.ServiceName == "IEC_Complaint.wf" && e.Folio == (complaintid).ToString()).FirstOrDefault();
            var serialNo = taskitem.serialNumber;
            int stepId = Convert.ToInt32(_request.GetByID(Convert.ToInt32(complaint.RequestId)).StepId);
   
            Response forcast23;
            if (complaintResponse.Id == 0)
            {
                forcast23 = await _Client.ComplaintResponse.Insert(complaintResponse);
                complaintResponse = JsonConvert.DeserializeObject<DTO.ComplaintResponse>(forcast23.Result.ToString());

                #region GeneralRequests
                Entity.GeneralRequest generalRequest = _request.GetByID(Convert.ToInt32(complaint.RequestId));
                generalRequest.StepId = 3;
                #endregion

                #region ActionHistory
                Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                #endregion

                var action = "Complete";
                ActionWorklistItemResponse response = await _K2Service.ActionWorklistItemAsync(serialNo, action, EmpName);
                var result = response.Body.ActionWorklistItemResult;


                complaintResponse.RequestId = complaint.RequestId;
                forcast23 = await _Client.ComplaintResponse.Update(complaintResponse);

                complaint.ComplaintStatusId = complaintResponse.ComplaintStatusId;
                var saving = await _Client.Complaint.Update(complaint);
                _dbContext.SaveChanges();

            }
            else
            {
                forcast23 = await _Client.ComplaintResponse.Update(complaintResponse);
            }
            if (forcast23.IsSuccess)
            {
                if (forcast23 != null)
                {
                    return RedirectToAction("MainPage", "SubscriperComplaint", complaintid);
                }
            }
            else
            {
                return View("ResponseToComplaint", complaintResponse.Id);
            }
            return View();
        }
    }
}
