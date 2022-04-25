using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Sadece Super Yönetici
        [HttpGet("List")]
        [Authorize(Roles = "3")]
        public IActionResult List()
        {
            // User.FindFirstValue(ClaimTypes.Name)
            var projects = _unitOfWork._projectRepository.GetProjects();
            if (projects.Count > 0)
            {
                return Ok(projects);
            }
            return NotFound();
        }

        // Kullanıcıya ait projeler
        [HttpGet("ProjectListOfUser")]
        [AllowAnonymous]
        public IActionResult ProjectListOfUser()
        {
            var projects = _unitOfWork._projectRepository.GetProjectsOfUser(User.FindFirstValue(ClaimTypes.Name));
            if (projects.Count > 0)
            {
                return Ok(projects);
            }
            return NotFound();
        }

        [HttpGet("FindProject/{id:int}")]
        public IActionResult FindProject(int id)
        {
            var project = _unitOfWork._projectRepository.GetProjectDetail(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }

        [HttpPost("NewProject")]
        public IActionResult NewProject([FromBody] ProjectCRUD request)
        {
            var project = _unitOfWork._projectRepository.Create(new Project
            {
                ProjectName = request.ProjectName,
                Description = request.Description,
                Note = request.Note,
                Status = request.Status,
                CreatedAt = DateTime.Now,
                WhoCreated = GetUser()[0].UserFullName,
                WhoUpdated = GetUser()[0].UserFullName,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,

            });
            _unitOfWork.Save();
            return Ok(project);
        }

        [HttpPut("UpdateProject/{id:int}")]
        public IActionResult UpdateProject(int id, [FromBody] ProjectCRUD request)
        {
            Project project = _unitOfWork._projectRepository.Find(id);
            if (project != null)
            {
                project.ProjectName = request.ProjectName;
                project.Description = request.Description;
                project.Note = request.Note;
                project.Status = request.Status;
                project.Status = request.Status;
                project.WhoUpdated = GetUser()[0].UserFullName;
                project.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(project);
            }
            return NotFound();
        }
        [HttpPut("DeleteProject/{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            Project project = _unitOfWork._projectRepository.Find(id);
            if (project != null)
            {
                project.IsDeleted = true;
                project.WhoUpdated = GetUser()[0].UserFullName;
                project.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(project);

            }
            return NotFound();
        }
        [HttpDelete("HardDeleteProject/{id:int}")]
        public IActionResult HardDeleteProject(int id)
        {
            Project project = _unitOfWork._projectRepository.Find(id);
            if (project != null)
            {
                _unitOfWork._projectRepository.Delete(project);
                _unitOfWork.Save();
                return Ok(project);
            }
            return NotFound();
        }
        private List<UserDto> GetUser()
        {
            return _unitOfWork._userRepository.GetUsers().Where(x => x.UserEmail == User.FindFirstValue(ClaimTypes.Name)).ToList();
        }
    }
}