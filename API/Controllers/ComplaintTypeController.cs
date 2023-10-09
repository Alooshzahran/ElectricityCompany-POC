using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public ComplaintTypeController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.ComplaintType> EntityComplaintType = _unitofwork.complaintType.GetAll().ToList();
            var DtoComplaintType = _Map.Map<List<DTO.ComplaintType>>(EntityComplaintType);
            return Ok(DtoComplaintType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityComplaintType = _unitofwork.complaintType.GetByID(Id);
            var DTOComplaintType = _Map.Map<DTO.ComplaintType>(EntityComplaintType);

            return Ok(DTOComplaintType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.ComplaintType ComplaintType)
        {

            var NewComplaintType = _Map.Map<Entity.ComplaintType>(ComplaintType);

            NewComplaintType.CreationDate = DateTime.UtcNow;
            _unitofwork.complaintType.Create(NewComplaintType);
            _unitofwork.Complete();

            ComplaintType.Id = NewComplaintType.Id;
            return Ok(ComplaintType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.ComplaintType ComplaintType)
        {


            var EntityComplaintType = _Map.Map<Entity.ComplaintType>(ComplaintType);
            _unitofwork.complaintType.Update(EntityComplaintType);
            _unitofwork.Complete();
            ComplaintType = _Map.Map<DTO.ComplaintType>(EntityComplaintType);
            return Ok(ComplaintType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.ComplaintType ComplaintType)
        {
            var EntityComplaintType = _unitofwork.complaintType.GetByID(ComplaintType.Id);
            if (EntityComplaintType != null)
            {


                EntityComplaintType.IsDeleted = true;
                EntityComplaintType.DeleteDate = DateTime.UtcNow;
                EntityComplaintType.DeleteUserId = ComplaintType.DeleteUserId;
                _unitofwork.Complete();
                var DTOComplaintType = _Map.Map<DTO.Attachment>(EntityComplaintType);
                return Ok(DTOComplaintType);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetComplaintTypeByCategoryId(int CategoryId)
        {
            var EntityLookup = _unitofwork.complaintType.GetComplaintTypeByCategoryId(CategoryId);
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
