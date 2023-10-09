using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public UserController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.User> EntityUser = _unitofwork.user.GetAll().ToList();
            var DtoUser = _Map.Map<List<DTO.User>>(EntityUser);
            return Ok(DtoUser);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityUser = _unitofwork.user.GetByID(Id);
            var DTOUser = _Map.Map<DTO.User>(EntityUser);

            return Ok(DTOUser);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.User User)
        {

            var NewUser = _Map.Map<Entity.User>(User);

            NewUser.CreationDate = DateTime.UtcNow;
            _unitofwork.user.Create(NewUser);
            _unitofwork.Complete();

            User.Id = NewUser.Id;
            return Ok(User);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.User User)
        {


            var EntityUser = _Map.Map<Entity.User>(User);
            _unitofwork.user.Update(EntityUser);
            _unitofwork.Complete();
            User = _Map.Map<DTO.User>(EntityUser);
            return Ok(User);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.User User)
        {
            var EntityUser = _unitofwork.user.GetByID(User.Id);
            if (EntityUser != null)
            {


                EntityUser.IsDeleted = true;
                EntityUser.DeleteDate = DateTime.UtcNow;
                EntityUser.DeleteUserId = User.DeleteUserId;
                _unitofwork.Complete();
                var DTOUser = _Map.Map<DTO.User>(EntityUser);
                return Ok(DTOUser);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
