using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Ticket : Base
    {
        public string TicketName { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
