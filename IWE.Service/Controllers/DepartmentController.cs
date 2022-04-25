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
    [HttpGet("ListDepartmentWithEmployees")]
    public IActionResult ListDepartmentWithEmployees()
    {
        return Ok(_unitOfWork._departmentRepository.GetDepartmentWithEmployees());
    }

    [HttpGet("FindDepartment/{id:int}")]
    public IActionResult FindDepartment(int id)
    {
        Department department = _unitOfWork._departmentRepository.Find(id);
        if (department != null)
        {
            return Ok(department);
        }
        return NotFound();
    }

    [HttpPost("AddDepartment")]
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
    [Route("UpdateDepartment/{id:int}")]
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
    [HttpPut]
    [Route("DeleteDepartment/{id:int}")]
    public IActionResult DeleteDepartment(int id)
    {
        Department department = _unitOfWork._departmentRepository.Find(id);
        if (department != null)
        {
            department.IsDeleted= true ;
            _unitOfWork._departmentRepository.Update(department);
            _unitOfWork.Save();
            return Ok(department);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("HardDeleteDepartment/{id:int}")]
    public IActionResult HardDeleteDepartment(int id)
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