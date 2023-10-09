using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public SubscriberController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Subscriber> EntitySubscriber = _unitofwork.subscriber.GetAll().ToList();
            var DtoSubscriber = _Map.Map<List<DTO.Subscriber>>(EntitySubscriber);
            return Ok(DtoSubscriber);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntitySubscriber = _unitofwork.subscriber.GetByID(Id);
            var DTOSubscriber = _Map.Map<DTO.Subscriber>(EntitySubscriber);

            return Ok(DTOSubscriber);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Subscriber Subscriber)
        {

            var NewSubscriber = _Map.Map<Entity.Subscriber>(Subscriber);

            NewSubscriber.CreationDate = DateTime.UtcNow;
            _unitofwork.subscriber.Create(NewSubscriber);
            _unitofwork.Complete();

            Subscriber.Id = NewSubscriber.Id;
            return Ok(Subscriber);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Subscriber Subscriber)
        {


            var EntitySubscriber = _Map.Map<Entity.Subscriber>(Subscriber);
            _unitofwork.subscriber.Update(EntitySubscriber);
            _unitofwork.Complete();
            Subscriber = _Map.Map<DTO.Subscriber>(EntitySubscriber);
            return Ok(Subscriber);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Subscriber Subscriber)
        {
            var EntitySubscriber = _unitofwork.subscriber.GetByID(Subscriber.Id);
            if (EntitySubscriber != null)
            {


                EntitySubscriber.IsDeleted = true;
                EntitySubscriber.DeleteDate = DateTime.UtcNow;
                EntitySubscriber.DeleteUserId = Subscriber.DeleteUserId;
                _unitofwork.Complete();
                var DTOSubscriber = _Map.Map<DTO.Attachment>(EntitySubscriber);
                return Ok(DTOSubscriber);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
