using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public  class TicketDto
    {
        public int Id { get; set; }
        public string TicketOwner { get; set; } = string.Empty;
        public string TicketName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}