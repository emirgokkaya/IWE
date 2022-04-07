using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public  class Ticket
    {
        public string TicketName { get; set; }
        public string WhoSentTicket { get; set; }
        public string TicketForWhichProject { get; set; }
        public DateTime TicketCreationTime { get; set; }
        public bool TicketStatus { get; set; }
        public string TicketReply { get; set; }
    }
}
