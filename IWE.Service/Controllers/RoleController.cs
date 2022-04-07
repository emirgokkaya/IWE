using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IUnitOfWork _uow;
        public RoleController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            return Ok(_uow._roleRepository.List());
        }
        [HttpGet( "{id}")]
        public IActionResult FindRole(int id)
        {
            return Ok(_uow._roleRepository.Find(id));
        }
        [HttpPost("{id}")]
        public IActionResult AddRole(RoleDto model)
        {
            return Ok(_uow._roleRepository.Create(new Role
            {
                RoleName = model.RoleName,
                CreatedAt= DateTime.Now,
                
                
            }));
        }
    }
}
