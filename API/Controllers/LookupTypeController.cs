using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public LookupTypeController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.LookupType> EntityLookupType = _unitofwork.LookupType.GetAll().ToList();
            var DtoLookupType = _Map.Map<List<DTO.LookupType>>(EntityLookupType);
            return Ok(DtoLookupType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityLookupType = _unitofwork.LookupType.GetByID(Id);
            var DTOLookupType = _Map.Map<DTO.LookupType>(EntityLookupType);

            return Ok(DTOLookupType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.LookupType LookupType)
        {

            var NewLookupType = _Map.Map<Entity.LookupType>(LookupType);

            NewLookupType.CreationDate = DateTime.UtcNow;
            _unitofwork.LookupType.Create(NewLookupType);
            _unitofwork.Complete();

            LookupType.Id = NewLookupType.Id;
            return Ok(LookupType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.LookupType LookupType)
        {


            var EntityLookupType = _Map.Map<Entity.LookupType>(LookupType);
            _unitofwork.LookupType.Update(EntityLookupType);
            _unitofwork.Complete();
            LookupType = _Map.Map<DTO.LookupType>(EntityLookupType);
            return Ok(LookupType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.LookupType LookupType)
        {
            var EntityLookupType = _unitofwork.LookupType.GetByID(LookupType.Id);
            if (EntityLookupType != null)
            {


                EntityLookupType.IsDeleted = true;
                EntityLookupType.DeleteDate = DateTime.UtcNow;
                EntityLookupType.DeleteUserId = LookupType. DeleteUserId;
                _unitofwork.Complete();
                var DTOLookupType = _Map.Map<DTO.Attachment>(EntityLookupType);
                return Ok(DTOLookupType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
