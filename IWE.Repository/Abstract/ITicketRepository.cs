using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    List<TicketDto> TicketList();

}