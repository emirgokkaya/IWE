using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IWE.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("TaskList")]
        public IActionResult TaskList()
        {
            return Ok(_unitOfWork._taskRepository.GetTask());
        }
        [HttpGet("TaskOfProjectList/{id:int}")]
        public IActionResult TaskOfProjectList(int id)
        {
            Project project = _unitOfWork._projectRepository.Find(id);
            if (project != null)
            {
                return Ok(_unitOfWork._taskRepository.GetTaskOfProject(id));

            }
            return NotFound();
        }
        [HttpGet("TaskOfUserList/{id:int}")]
        public IActionResult TaskOfUserList(int id)
        {
            User user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                return Ok(_unitOfWork._taskRepository.GetTaskOfUser(id));

            }
            return NotFound();
        }
        [HttpGet("MyTask")]
        public IActionResult MyTask()
        {

            return Ok(_unitOfWork._taskRepository.GetTaskOfProject(GetUser()[0].Id));

        }
        [HttpGet("FindTask/{id:int}")]
        public IActionResult FindTask(int id)
        {

            return Ok(_unitOfWork._taskRepository.Find(id));

        }
        [HttpPost("NewTask")]
        public IActionResult NewTask([FromBody] TaskCRUD request)
        {
            var task = _unitOfWork._taskRepository.Create(new Entity.Concrete.Task
            {
                TaskName = request.TaskName,
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                Status = request.Status,
                CreatedAt = DateTime.Now,
                WhoCreated = GetUser()[0].UserFullName,
                WhoUpdated = GetUser()[0].UserFullName,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
               
            });
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("UpdateTask/{id:int}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskCRUD request)
        {
            Entity.Concrete.Task task = _unitOfWork._taskRepository.Find(id);
            if (task != null)
            {
                task.TaskName = request.TaskName;
                task.Note = request.Note;
                task.UserId = request.UserId;
                task.ProjectId = request.ProjectId;
                task.Status = request.Status;
                task.WhoUpdated = GetUser()[0].UserFullName;
                task.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(task);
            }
            return NotFound();
        }
        [HttpPut("DeleteTask/{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            Entity.Concrete.Task task = _unitOfWork._taskRepository.Find(id);
            if (task != null)
            {
                task.IsDeleted = true;
                task.WhoUpdated = GetUser()[0].UserFullName;
                task.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(task);

            }
            return NotFound();
        }
        [HttpDelete("HardDeleteTask/{id:int}")]
        public IActionResult HardDeleteTask(int id)
        {
            Entity.Concrete.Task task = _unitOfWork._taskRepository.Find(id);
            if (task != null)
            {
                _unitOfWork._taskRepository.Delete(task);
                _unitOfWork.Save();
                return Ok(task);
            }
            return NotFound();
        }
        private List<UserDto> GetUser()
        {
            return _unitOfWork._userRepository.GetUsers().Where(x => x.UserEmail == User.FindFirstValue(ClaimTypes.Name)).ToList();
        }
    }
}
