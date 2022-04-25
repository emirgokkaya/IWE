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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            return Ok(_unitOfWork._categoryRepository.GetCategories());
        }

        [HttpGet("CategoryWithProjectList/{id:int}")]
        public IActionResult CategoryWithProjectList(int id)
        {
            return Ok(_unitOfWork._categoryRepository.GetCategoryWithProjects(id));

        }

        [HttpGet("FindCategory/{id:int}")]
        public IActionResult FindCategory(int id)
        {

            return Ok(_unitOfWork._categoryRepository.Find(id));

        }

        [HttpPost("NewCategory")]
        public IActionResult NewCategory([FromBody] CategoryCRUD request)
        {
            var category = _unitOfWork._categoryRepository.Create(new Category
            {
                CategoryName = request.CategoryName,
                Note = request.Note,
                Status = request.Status,
                CreatedAt = DateTime.Now,
                WhoCreated = GetUser()[0].UserFullName,
                WhoUpdated = GetUser()[0].UserFullName,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,

            });
            _unitOfWork.Save();
            return Ok(category);
        }

        [HttpPut("UpdateCategory/{id:int}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryCRUD request)
        {
            Category category = _unitOfWork._categoryRepository.Find(id);
            if (category != null)
            {
                category.CategoryName = request.CategoryName;
                category.Note = request.Note;
                category.Status = request.Status;
                category.WhoUpdated = GetUser()[0].UserFullName;
                category.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(category);
            }
            return NotFound();
        }
        [HttpPut("DeleteCategory/{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _unitOfWork._categoryRepository.Find(id);
            if (category != null)
            {
                category.IsDeleted = true;
                category.WhoUpdated = GetUser()[0].UserFullName;
                category.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(category);

            }
            return NotFound();
        }
        [HttpDelete("HardDeleteCategory/{id:int}")]
        public IActionResult HardDeleteCategory(int id)
        {
            Category category = _unitOfWork._categoryRepository.Find(id);
            if (category != null)
            {
                _unitOfWork._categoryRepository.Delete(category);
                _unitOfWork.Save();
                return Ok(category);
            }
            return NotFound();
        }

        private List<UserDto> GetUser()
        {
            return _unitOfWork._userRepository.GetUsers().Where(x => x.UserEmail == User.FindFirstValue(ClaimTypes.Name)).ToList();
        }
    }
}
