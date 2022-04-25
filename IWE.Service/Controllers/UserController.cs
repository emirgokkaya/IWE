using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IWE.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var users = _unitOfWork._userRepository.GetUsers();
            if (users.Count > 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("FindUser/{id:int}")]
        public IActionResult FindUser(int id)
        {
            User ?user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateUser/{id:int}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok(_unitOfWork._userRepository.StatusChange(id));
        }

        [HttpDelete]
        [Route("DeleteUser{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_unitOfWork._userRepository.SoftDeleteUser(id));
        }
    }
}