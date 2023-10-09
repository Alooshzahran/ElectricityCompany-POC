using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalReportController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public TechnicalReportController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.TechnicalReport> EntityTechnicalReport = _unitofwork.technicalReport.GetAll().ToList();
            var DtoTechnicalReport = _Map.Map<List<DTO.TechnicalReport>>(EntityTechnicalReport);
            return Ok(DtoTechnicalReport);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityTechnicalReport = _unitofwork.technicalReport.GetByID(Id);
            var DTOTechnicalReport = _Map.Map<DTO.TechnicalReport>(EntityTechnicalReport);

            return Ok(DTOTechnicalReport);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.TechnicalReport TechnicalReport)
        {

            var NewTechnicalReport = _Map.Map<Entity.TechnicalReport>(TechnicalReport);

            NewTechnicalReport.CreationDate = DateTime.UtcNow;
            _unitofwork.technicalReport.Create(NewTechnicalReport);
            _unitofwork.Complete();

            TechnicalReport.Id = NewTechnicalReport.Id;
            return Ok(TechnicalReport);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.TechnicalReport TechnicalReport)
        {


            var EntityTechnicalReport = _Map.Map<Entity.TechnicalReport>(TechnicalReport);
            _unitofwork.technicalReport.Update(EntityTechnicalReport);
            _unitofwork.Complete();
            TechnicalReport = _Map.Map<DTO.TechnicalReport>(EntityTechnicalReport);
            return Ok(TechnicalReport);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.TechnicalReport TechnicalReport)
        {
            var EntityTechnicalReport = _unitofwork.technicalReport.GetByID(TechnicalReport.Id);
            if (EntityTechnicalReport != null)
            {


                EntityTechnicalReport.IsDeleted = true;
                EntityTechnicalReport.DeleteDate = DateTime.UtcNow;
                EntityTechnicalReport.DeleteUserId = TechnicalReport.DeleteUserId;
                _unitofwork.Complete();
                var DTOTechnicalReport = _Map.Map<DTO.Attachment>(EntityTechnicalReport);
                return Ok(DTOTechnicalReport);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
