using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDeveloper { get; set; }
        public string TaskFromTicket { get; set; }
        public string TaskOwnedThisProject { get; set; }
    }
}
