using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public AuditController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Audit> EntityAudit = _unitofwork.audit.GetAll().ToList();
            var DtoAudit = _Map.Map<List<DTO.Audit>>(EntityAudit);
            return Ok(DtoAudit);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityAudit = _unitofwork.audit.GetByID(Id);
            var DTOAudit = _Map.Map<DTO.Audit>(EntityAudit);

            return Ok(DTOAudit);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Audit Audit)
        {

            var NewAudit = _Map.Map<Entity.Audit>(Audit);

            NewAudit.CreationDate = DateTime.UtcNow;
            _unitofwork.audit.Create(NewAudit);
            _unitofwork.Complete();

            Audit.Id = NewAudit.Id;
            return Ok(Audit);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Audit Audit)
        {


            var EntityAudit = _Map.Map<Entity.Audit>(Audit);
            _unitofwork.audit.Update(EntityAudit);
            _unitofwork.Complete();
            Audit = _Map.Map<DTO.Audit>(EntityAudit);
            return Ok(Audit);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Audit Audit)
        {
            var EntityAudit = _unitofwork.audit.GetByID(Audit.Id);
            if (EntityAudit != null)
            {


                EntityAudit.IsDeleted = true;
                EntityAudit.DeleteDate = DateTime.UtcNow;
                EntityAudit.DeleteUserId = Audit.DeleteUserId;
                _unitofwork.Complete();
                var DTOAudit = _Map.Map<DTO.Attachment>(EntityAudit);
                return Ok(DTOAudit);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
