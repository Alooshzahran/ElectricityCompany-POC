using Connecter.Client;
using Connecter.Models;
using Entity;
using Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using Repository;
using ServiceReference;
using UI.Repositries;

namespace UI.Controllers
{
    public class AuditController : Controller
    {
        readonly private IClientContainer _Client;
        IClientComplaintType _complaintType;
        private readonly IClientLookup _ClientLookup;
        private readonly IRepositoryGeneralRequest _request;
        private readonly IRepositoryActionHistory _ActionsHistory;
        private readonly IRepositoryAction _Actions;
        private readonly TaskActionSoapClient _K2Service;
        private readonly MyDbContext _dbContext;
        public AuditController(IClientContainer Client, IClientLookup ClientLookup, IClientComplaintType complaintType, IRepositoryGeneralRequest request, IRepositoryActionHistory ActionsHistory, TaskActionSoapClient K2Service, MyDbContext dbContext, IRepositoryAction Actions)
        {
            _Client = Client;
            _ClientLookup = ClientLookup;
            _complaintType = complaintType;
            _request = request;
            _ActionsHistory = ActionsHistory;
            _K2Service = K2Service;
            _Actions = Actions;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            int complaintid =Convert.ToInt32(Request.Cookies["ComplaintId"]);
            
            var EmpName = "Q.Abed";
            string serialNo = HttpContext.Request.Query["serialNo"].ToString();
            ViewBag.serialNo = serialNo;
            string stepId = Request.Cookies["stepId"];
            ViewBag.stepId = stepId;
            ViewBag.complaintid = complaintid;

            

            GetEmployeeTaskListResponse result = await _K2Service.GetEmployeeTaskListAsync(EmpName, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result.Body.GetEmployeeTaskListResult;
            K2TaskItem taskitem = Items.Where(e => e.ServiceName == "IEC_Complaint.wf" && e.Folio == complaintid.ToString()).FirstOrDefault();
            List<Entity.Action> actions = new List<Entity.Action>();
            if (taskitem != null)
            {
                foreach (var item in taskitem.Actions)
                {

                    Entity.Action x = _dbContext.Actions.FirstOrDefault(e => e.ActionNameEn == item);
                    if (stepId == "1")
                    {
                        actions.Add(x);
                    }
                    else if (stepId == "3")
                    {
                        if (x.ActionNameEn != "CompleteRemark")
                        {
                            actions.Add(x);
                        }
                    }
                    else
                    {
                        actions.Add(x);
                    }
                }
            }
            if(stepId == "1")
            {
                ViewBag.ShowstepId = "block";
            }else if(stepId == "3")
            {
                ViewBag.ShowstepId = "block";
            }
            else if(stepId == "5") 
            {
                ViewBag.ShowstepId = "block";
            }
            else
            {
                ViewBag.ShowstepId = "";
            }
           
           
            //var complaint = await _Client.Complaint.GetByID(complaintid);
            var GetAllEmployee = await _Client.Employee.GetAll();
            //var Employee = await _Client.Employee.GetByID(1);
            ViewBag.AllEmpName = new SelectList(GetAllEmployee, "Id", "NameArabic");
            var AuditStatus = await _ClientLookup.GetAllAuditStatus();
            ViewBag.AuditStatus = new SelectList(actions, "Id", "ActionNameAr") ;
            return View();
            
        }
        public async Task<ActionResult> Save(DTO.Audit audit)
        {
            var EmpName = "Q.Abed";
            
            var stepId = Convert.ToInt32(Request.Cookies["stepId"]);
            var complaintid = Convert.ToInt32(Request.Cookies["complaintid"]);
            DTO.Complaint complaint = await _Client.Complaint.GetByID(complaintid);

            GetEmployeeTaskListResponse result1 = await _K2Service.GetEmployeeTaskListAsync(EmpName, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result1.Body.GetEmployeeTaskListResult;
            K2TaskItem taskitem = Items.Where(e => e.ServiceName == "IEC_Complaint.wf" && e.Folio == (complaintid).ToString()).FirstOrDefault();
            var serialNo = taskitem.serialNumber;


            Response forcast23;
            if (audit.Id == 0)
            {
                if (stepId == 1)
                {
                    forcast23 = await _Client.Audit.Insert(audit);

                    audit = JsonConvert.DeserializeObject<DTO.Audit>(forcast23.Result.ToString());

                    #region GeneralRequests
                    Entity.GeneralRequest generalRequest = _request.GetByID(Convert.ToInt32(complaint.RequestId));
                    if (audit.AuditStatusId == 1012)
                    {
                        generalRequest.StepId = 2;
                    }else if(audit.AuditStatusId == 1013)
                    {
                        generalRequest.StepId = 6;
                    }
                    else
                    {
                        generalRequest.StepId = 6;

                    }
                    _dbContext.SaveChanges();
                    #endregion

                    #region ActionHistory
                    Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                    #endregion

                    string action = _Actions.GetAllAction().FirstOrDefault(e => e.Id == audit.AuditStatusId).ActionNameEn;

                    audit.RequestId = complaint.RequestId;

                    ActionWorklistItemResponse response = await _K2Service.ActionWorklistItemAsync(serialNo, action, EmpName);
                    var result = response.Body.ActionWorklistItemResult;

                    string date = DateTime.Now.ToString("yy");
                    complaint.ComplaintNo = date.PadRight(4,'0')+$"{complaint.RequestId}";
                    var newcomplaint = await _Client.Complaint.Update(complaint);
                    forcast23 = await _Client.Audit.Update(audit);
                    _dbContext.SaveChanges();
                }
                else if (stepId == 3)
                {
                    forcast23 = await _Client.Audit.Insert(audit);
                    #region GeneralRequests
                    Entity.GeneralRequest generalRequest =  _request.GetByID(Convert.ToInt32(complaint.RequestId));
                    #endregion
                    var action = "";
                    if (audit.AuditStatusId == 5)
                    {
                        generalRequest.StepId = 5;
                        action = "Complete";
                    }
                    else
                    {
                        generalRequest.StepId = 2;
                        action = "Return";
                    }
                    _dbContext.SaveChanges();
                    #region ActionHistory
                    Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                    #endregion

                    audit.RequestId = complaint.RequestId;


                   
                    ActionWorklistItemResponse response = await _K2Service.ActionWorklistItemAsync(serialNo, action, EmpName);
                    var result = response.Body.ActionWorklistItemResult;

                    forcast23 = await _Client.Audit.Update(audit);  
                    if(complaint.ComplaintSourceId == 3)
                    {
                        if(complaint.ComplaintTypeId == 13)
                        {
                            generalRequest.StepId = 6;
                        }
                    }
                    _dbContext.SaveChanges();
                }
                else
                {
                    string action = "Approve";
                   
                    forcast23 = await _Client.Audit.Insert(audit);
                    #region GeneralRequests
                    Entity.GeneralRequest generalRequest = _request.GetByID(Convert.ToInt32(complaint.RequestId));
                    #endregion
                    if (audit.AuditStatusId == 1012)
                    {
                        generalRequest.StepId = 6;
                    }
                    else
                    {
                        generalRequest.StepId = 5;
                    }
                    _dbContext.SaveChanges();
                    #region ActionHistory
                    Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                    #endregion

                    ActionWorklistItemResponse response = await _K2Service.ActionWorklistItemAsync(serialNo, action, EmpName);
                    var result = response.Body.ActionWorklistItemResult;

                    //ServiceReference.StartProcessResponse Response = await _K2Service.StartProcessAsync(EmpName, audit.Id, generalRequest.RequestId, UI.Classes.Constants.ProcessIEC_Complaint);
                    //int ProcessID = int.Parse(Response.Body.StartProcessResult.ToString());
                    //generalRequest.ProcessId = ProcessID;
                    _dbContext.SaveChanges();
                }
            }
            else
            {
                forcast23 = await _Client.Audit.Update(audit);
            }
            if (forcast23.IsSuccess)
            {
                if (forcast23 != null)
                {
                    return RedirectToAction("MainPage", "SubscriperComplaint" , complaintid);
                }
            }
            else
            {
                return View("MainPage", audit.Id);
            }
            return View();
        }
    }
}
