using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        return Ok(_unitOfWork._departmentRepository.List());
    }

    [HttpGet("{id:int}")]
    public IActionResult FindDepartment(int id)
    {
        Department department = _unitOfWork._departmentRepository.Find(id);
        if (department != null)
        {
            return Ok(department);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult AddDepartment([FromBody] DepartmentDto model)
    {
        _unitOfWork._departmentRepository.Create(new Department
        {
            DepartmentName = model.DepartmentName,
            Note = "Add new department",
            Status = true,
            IsDeleted = false,
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
            WhoCreated = "iwe",
            WhoUpdated = "iwe"
        });
        _unitOfWork.Save();
        return Ok(model.DepartmentName);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateDepartment(int id, [FromBody] DepartmentDto model)
    {
        Department department = _unitOfWork._departmentRepository.Find(id);
        if (department != null)
        {
            department.DepartmentName = model.DepartmentName;
            _unitOfWork._departmentRepository.Update(department);
            _unitOfWork.Save();
            return Ok(department);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteDepartment(int id)
    {
        Department department = _unitOfWork._departmentRepository.Find(id);
        if (department != null)
        {
            _unitOfWork._departmentRepository.Delete(department);
            _unitOfWork.Save();
            return Ok(department);
        }
        return NotFound();
    }
}