using Connecter.Client;
using Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using ServiceReference;
using System;
using UI.Repositries;

namespace UI.Controllers
{
    public class MyTasksController : Controller
    {

        private readonly IClientContainer _clientContainer;
        //private readonly RepositoryActionHistory _repositoryActionHistory;
        private readonly IRepositoryGeneralRequest _generalRequest;
        private readonly TaskActionSoapClient _k2service;
        //private readonly List<Entity.Action> _Actions;
        private readonly IRepositoryAction _action;
        private readonly IRepositoryServices _repositoryServices;
        private readonly MyDbContext _dbContext;
        public MyTasksController( IClientContainer clientContainer, TaskActionSoapClient k2service, IRepositoryServices repositoryServices,IRepositoryAction action, IRepositoryGeneralRequest generalRequest, MyDbContext dbContext)
        {

            _clientContainer = clientContainer;
            //_repositoryActionHistory = repositoryActionHistory;
            _generalRequest = generalRequest;
            _k2service = k2service;
            //_Actions = Actions;
            _action = action;
            _repositoryServices = repositoryServices;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("ComplaintId", $"0", options);
            var EmpName = "Q.Abed";
            ViewBag.Services = _repositoryServices.GetAllServices();
            ViewBag.Actions = _action.GetAllAction();
            var Complaints = await _clientContainer.Complaint.GetAll();
            ViewBag.AllComplaints = Complaints;
            GetEmployeeTaskListResponse result = await _k2service.GetEmployeeTaskListAsync(EmpName, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result.Body.GetEmployeeTaskListResult;
            K2TaskItem[] taskitem = Items.Where(e => e.ServiceName == "IEC_Complaint.wf").ToArray();
            
            foreach (var item in taskitem)
            {
                
            }
            return View(taskitem.ToList());
        }
        public async Task<IActionResult> Details(int Id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("ComplaintId", $"{Id}", options);

            string serialNo = HttpContext.Request.Query["serialNo"].ToString(); 
            ViewBag.serialNo = serialNo;
            var complaint = await _clientContainer.Complaint.GetByID(Id);

            

            var generalRequest =  _generalRequest.GetAll();
            Entity.GeneralRequest x = generalRequest.Where(e => e.RequestId == complaint.RequestId).FirstOrDefault();

            if(x != null)
            {
                var stepid = x.StepId;
                var stepname = _dbContext.GeneralSteps.Where(e=>e.Stid == stepid).FirstOrDefault().StepNameAr;
                ViewBag.Step = stepname;
                ViewBag.StepId = stepid;
            }
            return View(complaint);
        }
    }
}
