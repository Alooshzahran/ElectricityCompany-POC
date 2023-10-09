using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintCategoryController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public ComplaintCategoryController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.ComplaintCategory> EntityComplaintCategory = _unitofwork.complaintCategory.GetAll().ToList();
            var DtoComplaintCategory = _Map.Map<List<DTO.ComplaintCategory>>(EntityComplaintCategory);
            return Ok(DtoComplaintCategory);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityComplaintCategory = _unitofwork.complaintCategory.GetByID(Id);
            var DTOComplaintCategory = _Map.Map<DTO.ComplaintCategory>(EntityComplaintCategory);

            return Ok(DTOComplaintCategory);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.ComplaintCategory ComplaintCategory)
        {

            var NewComplaintCategory = _Map.Map<Entity.ComplaintCategory>(ComplaintCategory);

            NewComplaintCategory.CreationDate = DateTime.UtcNow;
            _unitofwork.complaintCategory.Create(NewComplaintCategory);
            _unitofwork.Complete();

            ComplaintCategory.Id = NewComplaintCategory.Id;
            return Ok(ComplaintCategory);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.ComplaintCategory ComplaintCategory)
        {


            var EntityComplaintCategory = _Map.Map<Entity.ComplaintCategory>(ComplaintCategory);
            _unitofwork.complaintCategory.Update(EntityComplaintCategory);
            _unitofwork.Complete();
            ComplaintCategory = _Map.Map<DTO.ComplaintCategory>(EntityComplaintCategory);
            return Ok(ComplaintCategory);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.ComplaintCategory ComplaintCategory)
        {
            var EntityComplaintCategory = _unitofwork.complaintCategory.GetByID(ComplaintCategory.Id);
            if (EntityComplaintCategory != null)
            {


                EntityComplaintCategory.IsDeleted = true;
                EntityComplaintCategory.DeleteDate = DateTime.UtcNow;
                EntityComplaintCategory.DeleteUserId = ComplaintCategory.DeleteUserId;
                _unitofwork.Complete();
                var DTOComplaintCategory = _Map.Map<DTO.Attachment>(EntityComplaintCategory);
                return Ok(DTOComplaintCategory);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
