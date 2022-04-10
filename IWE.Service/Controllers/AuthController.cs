using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Service.Authorization;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private User _user;
        private Department _department;
        private Role _role;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration, User user,Department department, Role role)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _user = user;
            _department = department;   
            _role = role;
        }
        
        [HttpPost("login")]
        public ActionResult Login(LoginDto userLogin)
        {
            User user = _unitOfWork._authRepository.Login(userLogin.Email, userLogin.Password);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                return Ok(new
                {
                    user = user,
                    token = token
                });
            }
            return NotFound();
        }
        
        [HttpPost("register")]
        public ActionResult Register(RegisterDto request)
        {
                               
            _user.FirstName = request.FirstName;
            _user.LastName = request.LastName;
            _user.Email = request.Email;
            _department.DepartmentName = request.Department.DepartmentName;
            _role.RoleName = request.Role.RoleName;
            _unitOfWork._authRepository.Register(_user, request.Password);
            return Ok(_user);
        }
    }
}