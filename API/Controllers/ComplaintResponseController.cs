using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintResponseController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public ComplaintResponseController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.ComplaintResponse> EntityComplaintResponse = _unitofwork.complaintResponse.GetAll().ToList();
            var DtoComplaintResponse = _Map.Map<List<DTO.ComplaintResponse>>(EntityComplaintResponse);
            return Ok(DtoComplaintResponse);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityComplaintResponse = _unitofwork.complaintResponse.GetByID(Id);
            var DTOComplaintResponse = _Map.Map<DTO.ComplaintResponse>(EntityComplaintResponse);

            return Ok(DTOComplaintResponse);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.ComplaintResponse ComplaintResponse)
        {

            var NewComplaintResponse = _Map.Map<Entity.ComplaintResponse>(ComplaintResponse);

            NewComplaintResponse.CreationDate = DateTime.UtcNow;
            _unitofwork.complaintResponse.Create(NewComplaintResponse);
            _unitofwork.Complete();

            ComplaintResponse.Id = NewComplaintResponse.Id;
            return Ok(ComplaintResponse);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.ComplaintResponse ComplaintResponse)
        {


            var EntityComplaintResponse = _Map.Map<Entity.ComplaintResponse>(ComplaintResponse);
            _unitofwork.complaintResponse.Update(EntityComplaintResponse);
            _unitofwork.Complete();
            ComplaintResponse = _Map.Map<DTO.ComplaintResponse>(EntityComplaintResponse);
            return Ok(ComplaintResponse);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.ComplaintResponse ComplaintResponse)
        {
            var EntityComplaintResponse = _unitofwork.complaintResponse.GetByID(ComplaintResponse.Id);
            if (EntityComplaintResponse != null)
            {


                EntityComplaintResponse.IsDeleted = true;
                EntityComplaintResponse.DeleteDate = DateTime.UtcNow;
                EntityComplaintResponse.DeleteUserId = ComplaintResponse.DeleteUserId;
                _unitofwork.Complete();
                var DTOComplaintResponse = _Map.Map<DTO.Attachment>(EntityComplaintResponse);
                return Ok(DTOComplaintResponse);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
