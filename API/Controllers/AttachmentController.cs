using API.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public AttachmentController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Attachment> EntityAttachment = _unitofwork.attachment.GetAll().ToList();
            var DtoAttachment = _Map.Map<List<DTO.Attachment>>(EntityAttachment);
            return Ok(DtoAttachment);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityAttachmentType = _unitofwork.attachment.GetByID(Id);
            var DTOAttachmentType = _Map.Map<DTO.Attachment>(EntityAttachmentType);

            return Ok(DTOAttachmentType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Attachment Attachment)
        {

            var NewAttachment = _Map.Map<Entity.Attachment>(Attachment);

            NewAttachment.CreationDate = DateTime.UtcNow;
            _unitofwork.attachment.Create(NewAttachment);
            _unitofwork.Complete();

            Attachment.Id = NewAttachment.Id;
            return Ok(Attachment);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Attachment Attachment)
        {


            var EntityAttachment = _Map.Map<Entity.Attachment>(Attachment);
            _unitofwork.attachment.Update(EntityAttachment);
            _unitofwork.Complete();
            Attachment = _Map.Map<DTO.Attachment>(EntityAttachment);
            return Ok(Attachment);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Attachment Attachment)
        {
            var EntityAttachment = _unitofwork.attachment.GetByID(Attachment.Id);
            if (EntityAttachment != null)
            {


                EntityAttachment.IsDeleted = true;
                EntityAttachment.DeleteDate = DateTime.UtcNow;
                EntityAttachment.DeleteUserId = Attachment.DeleteUserId;
                _unitofwork.Complete();
                var DTOAttachment = _Map.Map<DTO.Attachment>(EntityAttachment);
                return Ok(DTOAttachment);
            }
            else
            {
                return NotFound();
            }


        }

    }
}

