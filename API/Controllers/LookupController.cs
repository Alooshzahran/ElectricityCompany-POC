using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public LookupController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Lookup> EntityLookup = _unitofwork.Lookup.GetAll().ToList();
            var DtoLookup = _Map.Map<List<DTO.Lookup>>(EntityLookup);
            return Ok(DtoLookup);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityLookup = _unitofwork.Lookup.GetByID(Id);
            var DTOLookup = _Map.Map<DTO.Lookup>(EntityLookup);

            return Ok(DTOLookup);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Lookup Lookup)
        {

            var NewLookup = _Map.Map<Entity.Lookup>(Lookup);

            NewLookup.CreationDate = DateTime.UtcNow;
            _unitofwork.Lookup.Create(NewLookup);
            _unitofwork.Complete();

            Lookup.Id = NewLookup.Id;
            return Ok(Lookup);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Lookup Lookup)
        {


            var EntityLookup = _Map.Map<Entity.Lookup>(Lookup);
            _unitofwork.Lookup.Update(EntityLookup);
            _unitofwork.Complete();
            Lookup = _Map.Map<DTO.Lookup>(EntityLookup);
            return Ok(Lookup);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Lookup Lookup)
        {
            var EntityLookup = _unitofwork.Lookup.GetByID(Lookup.Id);
            if (EntityLookup != null)
            {


                EntityLookup.IsDeleted = true;
                EntityLookup.DeleteDate = DateTime.UtcNow;
                EntityLookup.DeleteUserId = Lookup.DeleteUserId;
                _unitofwork.Complete();
                var DTOLookup = _Map.Map<DTO.Attachment>(EntityLookup);
                return Ok(DTOLookup);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDept(int id)
        {
            var EntityLookup = _unitofwork.Lookup.GetDepartments(id);
            if (EntityLookup != null)
            {
                return Ok(EntityLookup.NameArabic);
            }
            else {
                return NotFound();
            }

        } 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllMethod()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllComplaintMethod();
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else {
                return NotFound();
            }

        } 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllArea()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllArea();
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else {
                return NotFound();
            }

        } 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllparties()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllComplainingparties();
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllSubType(int Id)
        {
            var EntityLookup = _unitofwork.Lookup.GetSubType(Id);
            if (EntityLookup != null)
            {
                return Ok(EntityLookup.NameArabic);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllComplaintStatus()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllComplaintStatus();
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllExportoffice()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllExportoffice();
            if (EntityLookup != null)
            {
                return Ok(EntityLookup);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllAuditStatus()
        {
            var EntityLookup = _unitofwork.Lookup.GetAllAuditStatus();
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
