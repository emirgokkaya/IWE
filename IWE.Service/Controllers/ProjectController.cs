using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        [HttpGet]
        [Authorize(Roles = "3")]
        // Sadece Super Yönetici
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

        [HttpGet]
        [AllowAnonymous]
        // Kullanıcıya ait projeler
        public IActionResult ProjectListOfUser()
        {
            var projects = _unitOfWork._projectRepository.GetProjectsOfUser(User.FindFirstValue(ClaimTypes.Name));
            if (projects.Count > 0)
            {
                return Ok(projects);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult FindProject(int id)
        {
            var project = _unitOfWork._projectRepository.GetProjectDetail(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }
        
    }
}