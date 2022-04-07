using System.Security.Claims;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers;

[Route("api/[controller]/[action]")]
[Authorize(Roles = "1")]
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
        Console.WriteLine(User);
        return _unitOfWork._roleRepository.List();
    }
}