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
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            return Ok(_unitOfWork._ticketRepository.TicketList());
        }
        [HttpGet("TicketOfUser")]
        public IActionResult UserTickets()
        {
            return Ok(_unitOfWork._ticketRepository.List().Where(x => x.UserId == GetUser()[0].Id && x.IsDeleted==false));
        }
        [HttpGet("FindTicket/{id:int}")]
        public IActionResult FindTicket(int id)
        {
            Ticket  ticket = _unitOfWork._ticketRepository.Find(id);
            if (ticket != null)
            {
                return Ok(ticket);
            }
            return NotFound();
        }
        [HttpPost ("NewTicket")]
        public IActionResult CreateTicket([FromBody] TicketDto request)
        {

            var ticket = _unitOfWork._ticketRepository.Create(new Ticket
            {

                TicketName = request.TicketName,
                Note = request.Note,
                Status = true,
                IsDeleted = false,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                WhoCreated = GetUser()[0].UserFullName,
                WhoUpdated = GetUser()[0].UserFullName,
                UserId = GetUser()[0].Id

            }); 
            _unitOfWork.Save();
            return Ok( ticket);
        }
        [HttpPut("UpdateTicket/{id:int}")]
        public IActionResult UpdateTicket(int id , [FromBody]TicketDto request)
        {
            Ticket ticket = _unitOfWork._ticketRepository.Find(id);
            if (ticket != null)
            {
                ticket.TicketName = request.TicketName;
                ticket.Note = request.Note;
                ticket.WhoUpdated = GetUser()[0].UserFullName;
                ticket.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(ticket);
            }
            return NotFound();
        }
        [HttpPut("DeleteTicket/{id:int}")]
        public IActionResult DeleteTicket(int id )
        {
            Ticket ticket = _unitOfWork._ticketRepository.Find(id);
            if (ticket != null)
            {
                ticket.IsDeleted = true;
                ticket.WhoUpdated = GetUser()[0].UserFullName;
                ticket.UpdatedAt = DateTime.Now;
                _unitOfWork.Save();
                return Ok(ticket);

            }
            return NotFound();
        }
        [HttpDelete("HardDeleteTicket/{id:int}")]
        public IActionResult HardDeleteTicket(int id )
        {
            Ticket ticket = _unitOfWork._ticketRepository.Find(id);
            if (ticket != null)
            {
               _unitOfWork._ticketRepository.Delete(ticket);
                _unitOfWork.Save();
                return Ok(ticket);
            }
            return NotFound();
        }

        private List<UserDto> GetUser()
        {
            return _unitOfWork._userRepository.GetUsers().Where(x => x.UserEmail == User.FindFirstValue(ClaimTypes.Name)).ToList();
        }
    }

}
