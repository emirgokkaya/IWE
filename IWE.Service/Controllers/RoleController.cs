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
        
        [HttpGet( "{id:int}")]
        public IActionResult FindRole(int id)
        {
            Role role = _uow._roleRepository.Find(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult AddRole([FromBody] RoleDto model)
        {
            _uow._roleRepository.Create(new Role
            {
                RoleName = model.RoleName,
                CreatedAt = DateTime.Now,
                Status = true,
                IsDeleted = false,
                UpdatedAt = DateTime.Now,
                WhoCreated = "iwe",
                WhoUpdated = "iwe",
                Note = "Add new role",
            });
            _uow.Save();
            return Ok(model);
        }

        [HttpPut()]
        [Route("{id:int}")]
        public IActionResult UpdateRole(int id, [FromBody] RoleDto model)
        {
            Role role = _uow._roleRepository.Find(id);
            if (role != null)
            {
                role.RoleName = model.RoleName;
                _uow._roleRepository.Update(role);
                _uow.Save();
                return Ok(role);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRole(int id)
        {
            Role role = _uow._roleRepository.Find(id);
            if (role != null)
            {
                _uow._roleRepository.Delete(role);
                _uow.Save();
                return Ok(role);
            }
            return NotFound();
        }
    }
}