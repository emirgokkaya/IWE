using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // GET
    [HttpGet(Name = "List")]
    public object List()
    {
        return _unitOfWork._roleRepository.List();
    }
}