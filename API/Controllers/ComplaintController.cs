using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public ComplaintController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Complaint> EntityComplaint = _unitofwork.complaint.GetAll().ToList();
            var DtoComplaint = _Map.Map<List<DTO.Complaint>>(EntityComplaint);
            return Ok(DtoComplaint);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityComplaint = _unitofwork.complaint.GetByID(Id);
            var DTOComplaint = _Map.Map<DTO.Complaint>(EntityComplaint);

            return Ok(DTOComplaint);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Complaint Complaint)
        {

            var NewComplaint = _Map.Map<Entity.Complaint>(Complaint);

            NewComplaint.CreationDate = DateTime.UtcNow;
            _unitofwork.complaint.Create(NewComplaint);
            _unitofwork.Complete();

            Complaint.Id = NewComplaint.Id;
            return Ok(Complaint);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Complaint Complaint)
        {


            var EntityComplaint = _Map.Map<Entity.Complaint>(Complaint);
            _unitofwork.complaint.Update(EntityComplaint);
            _unitofwork.Complete();
            Complaint = _Map.Map<DTO.Complaint>(EntityComplaint);
            return Ok(Complaint);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Complaint Complaint)
        {
            var EntityComplaint = _unitofwork.complaint.GetByID(Complaint.Id);
            if (EntityComplaint != null)
            {


                EntityComplaint.IsDeleted = true;
                EntityComplaint.DeleteDate = DateTime.UtcNow;
                EntityComplaint.DeleteUserId = Complaint.DeleteUserId;
                _unitofwork.Complete();
                var DTOComplaint = _Map.Map<DTO.Attachment>(EntityComplaint);
                return Ok(DTOComplaint);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
