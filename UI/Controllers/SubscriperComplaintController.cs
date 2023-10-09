using Connecter.Client;
using Connecter.Models;
using DTO;
using Entity;
using Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repository;
using ServiceReference;
using UI.Classes;
using UI.Repositries;

namespace Portal.Controllers
{
    public class SubscriperComplaintController : Controller
    {
        readonly private IClientContainer _Client;
        readonly private IClientComplaintType _complaintType;
        private readonly IClientLookup _ClientLookup;
        private readonly IRepositoryGeneralRequest _request;
        private readonly IRepositoryActionHistory _ActionsHistory;
        private readonly TaskActionSoapClient _K2Service;
        //private readonly IUnitofwork unitofwork;
        private readonly MyDbContext _dbContext;
        public SubscriperComplaintController(IClientContainer Client, IClientLookup ClientLookup, IClientComplaintType complaintType, IRepositoryGeneralRequest request, IRepositoryActionHistory ActionsHistory, TaskActionSoapClient K2Service, MyDbContext dbContext)
        {
            _Client = Client;
            _ClientLookup = ClientLookup;
            _complaintType = complaintType;
            _request = request;
            _ActionsHistory = ActionsHistory;
            _K2Service = K2Service;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> MainPage(int id)
        {
            int complaintid = Convert.ToInt32(Request.Cookies["ComplaintId"]);
            if (complaintid > 0)
            {
                id = complaintid;
            }
            if (id != 0)
            {
                var complaint = await _Client.Complaint.GetByID(id);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("ComplaintId", $"{id}", options);
                int stepId = Convert.ToInt32(_request.GetAll().FirstOrDefault(e=>e.RequestId == complaint.RequestId).StepId);
                Response.Cookies.Append("stepId", $"{stepId}", options);
                var Employee = await _Client.Employee.GetByID(1);
                ViewBag.EmpName = Employee.NameArabic;
                var Dept = await _Client.Lookup.GetByID(3);
                ViewBag.EmpDept = Dept.NameArabic;
               
                var EmpBranch = await _ClientLookup.GetDept(Convert.ToInt32(Employee.DepartmentId));
                ViewBag.EmpBranch = EmpBranch;
                var complaintParties = await _ClientLookup.GetAllparties();
                ViewBag.complaintParties = new SelectList(complaintParties, "Id", "NameArabic");
                var ComplaintMethod = await _ClientLookup.GetAllMethod();
                ViewBag.ComplaintMethod = new SelectList(ComplaintMethod, "Id", "NameArabic");
                var SubscriberName = await _Client.Subscriber.GetByID(Convert.ToInt32(complaint.SubscriberId));
                if (SubscriberName != null)
                {
                    ViewBag.SubscriberName = SubscriberName.Name;
                    var SubType = await _ClientLookup.GetSubType(Convert.ToInt32(SubscriberName.SubscriptionTypeId));
                    ViewBag.SubType = SubType;
                }
                else
                {
                    ViewBag.SubscriberName ="";
                    ViewBag.SubType = "";
                }
                var AllArea = await _ClientLookup.GetAllArea();
                ViewBag.AllArea = new SelectList(AllArea, "Id", "NameArabic");

                var AllComplaintCategory = await _Client.ComplaintCategory.GetAll();
                ViewBag.AllComplaintCategory = new SelectList(AllComplaintCategory, "Id", "Name");
                var complaintCategory = await _Client.ComplaintCategory.GetByID(Convert.ToInt32(complaint.ComplaintSourceId));
                ViewBag.complaintCategory = complaintCategory.Name;

                var AllComplaintType = await _complaintType.GetComplaintTypesByCategoryId(Convert.ToInt32(complaint.ComplaintTypeId));
                ViewBag.AllComplaintType = new SelectList(AllComplaintType, "Id", "Name");
                var complaintType = await _Client.ComplaintType.GetByID(Convert.ToInt32(complaint.ComplaintTypeId));
                ViewBag.complaintType = complaintType.Name;
                if (complaint.CreationDate != null)
                {
                    if(complaint.ComplaintSourceId != 2)
                    {
                        TimeSpan timeSpan = DateTime.Now - (DateTime)complaint.CreationDate;

                        var difference = timeSpan.Days;

                        ViewBag.Difference = 15 - difference;
                    }
                    else
                    {
                        TimeSpan timeSpan = DateTime.Now - (DateTime)complaint.CreationDate;

                        var difference = timeSpan.Days;

                        ViewBag.Difference = 20 - difference;
                    }

                }
                else
                {
                    ViewBag.Difference = 15;
                }
                var xxx = 0;
                return View(complaint);
            }
            else
            {
                var Employee = await _Client.Employee.GetByID(1);
                var name = Employee.NameArabic;
                ViewBag.EmpName = name;
                var Dept = await _Client.Lookup.GetByID(3);
                ViewBag.EmpDept = Dept.NameArabic;
                var EmpBranch = await _ClientLookup.GetDept(Convert.ToInt32(Employee.DepartmentId));
                ViewBag.EmpBranch = EmpBranch;
                var complaintParties = await _ClientLookup.GetAllparties();
                ViewBag.complaintParties = new SelectList(complaintParties, "Id", "NameArabic");
                var ComplaintMethod = await _ClientLookup.GetAllMethod();
                ViewBag.ComplaintMethod = new SelectList(ComplaintMethod, "Id", "NameArabic");

                var AllArea = await _ClientLookup.GetAllArea();
                ViewBag.AllArea = new SelectList(AllArea, "Id", "NameArabic");
                //var SubscriberName = await _Client.Subscriber.GetByID(Convert.ToInt32(complaint.SubscriberId));
                var Allsubscriber = await _Client.Subscriber.GetAll();
                ViewBag.Allsubscriber = new SelectList(Allsubscriber, "Id", "Name");
                ViewBag.SubscriberName = "";

                var AllComplaintCategory = await _Client.ComplaintCategory.GetAll();
                ViewBag.AllComplaintCategory = new SelectList(AllComplaintCategory, "Id", "Name"); ;
                //var ComplaintCategory = await _Client.ComplaintCategory.GetByID(Convert.ToInt32(complaint.ComplaintSourceId));
                ViewBag.CompanyCategory = "";
                var AllComplaintType = await _Client.ComplaintType.GetAll();
                ViewBag.AllComplaintType = new SelectList(AllComplaintType, "Id", "Name");



                var ComplainType1 = await _complaintType.GetComplaintTypesByCategoryId(1);
                ViewBag.ComplainType1 = new SelectList(ComplainType1, "Id", "Name");
                var ComplainType2 = await _complaintType.GetComplaintTypesByCategoryId(2);
                ViewBag.ComplainType2 = new SelectList(ComplainType2, "Id", "Name");
                var ComplainType3 = await _complaintType.GetComplaintTypesByCategoryId(3);
                ViewBag.ComplainType3 = new SelectList(ComplainType3, "Id", "Name");
                var ComplainType4 = await _complaintType.GetComplaintTypesByCategoryId(4);
                ViewBag.ComplainType4 = new SelectList(ComplainType4, "Id", "Name");
                var ComplainType5 = await _complaintType.GetComplaintTypesByCategoryId(5);
                ViewBag.ComplainType5 = new SelectList(ComplainType5, "Id", "Name");


                //var ComplaintType = await _Client.ComplaintType.GetByID(Convert.ToInt32(complaint.ComplaintTypeId));
              

                //var SubType = await _ClientLookup.GetSubType(Convert.ToInt32(SubscriberName.SubscriptionTypeId));
                //ViewBag.SubType = SubType;
                var complaint = new DTO.Complaint();
                return View(complaint);

            }
        }
        public async Task<ActionResult> Save(DTO.Complaint complaint)
        {
            var ComplaintTypeId = Request.Form["ComplaintTypeId"];
           
            foreach (var item in ComplaintTypeId)
            {
               
                if (item != "")
                {
                    complaint.ComplaintTypeId = Convert.ToInt32(item);
                }
            }

            //if (complaint.ComplaintTypeId == null)
            //{
            //    complaint.ComplaintTypeId = 1;
            //}
            complaint.IsDeleted = false;
            if(complaint.CreationDate == null)
            {
                complaint.CreationDate = DateTime.Now;
            }
            
            Response forcast;
            if (complaint.Id == 0)
            {
                 forcast = await _Client.Complaint.Insert(complaint);
                complaint = JsonConvert.DeserializeObject<DTO.Complaint>(forcast.Result.ToString());
                #region GeneralRequests
                Entity.GeneralRequest generalRequest = await _request.InsertGeneralRequest(complaint.Id, (int)UI.Classes.ServiceTypes.Complaint, (int)UI.Classes.Steps.Requester);
                #endregion

                #region ActionHistory
                Entity.ActionHistory ActionsHistory = await _ActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                #endregion
                var EmpName = "Q.abed";
               
                complaint.RequestId = generalRequest.RequestId;
                
                
                ServiceReference.StartProcessResponse Response = await _K2Service.StartProcessAsync(EmpName, complaint.Id, generalRequest.RequestId,UI.Classes.Constants.ProcessIEC_Complaint);
                int ProcessID = int.Parse(Response.Body.StartProcessResult.ToString());
                generalRequest.ProcessId = ProcessID;
                forcast = await _Client.Complaint.Update(complaint);
                _dbContext.SaveChanges();

            }
            else
            {
                  forcast = await _Client.Complaint.Update(complaint);
            }
            if (forcast.IsSuccess)
            {
                if (forcast != null)
                {
                    return RedirectToAction("Index","Complaint");
                }
            }
            else
            {
                return View("MainPage", complaint.Id);
            }
            return View();
        }
    }
}
