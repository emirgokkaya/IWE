using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    public TicketRepository(IWEContext context) : base(context)
    {
    }

   

    public List<TicketDto> TicketList()
    {
        return Set().Select(t => new TicketDto {  
            Id = t.Id,
            TicketOwner = t.User.FirstName +" "+ t.User.LastName,
            TicketName = t.TicketName,
            Note = t.Note
        }).ToList();

    }
}