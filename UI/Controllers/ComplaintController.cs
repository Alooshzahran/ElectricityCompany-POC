using Connecter.Client;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace Portal.Controllers
{
    public class ComplaintController : Controller
    {
        readonly private IClientContainer _Client;

        public ComplaintController(IClientContainer Client, TaskActionSoapClient k2Service)
        {
            _Client = Client;

        }
        public async Task<IActionResult> Index()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("ComplaintId", $"0", options);
            var complaint = await _Client.Complaint.GetAll(); 

            var complaintStatue = await _Client.Lookup.GetAll();
            ViewBag.complaintStatue = complaintStatue;

            return View(complaint);
        }
        
    }
}
