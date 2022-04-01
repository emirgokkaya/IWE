using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    public TicketRepository(IWEContext context) : base(context)
    {
    }
}