using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class TaskDto
    {
        public string TaskName { get; set; }
        public string TaskDeveloper { get; set; }
        public string TaskByTicket { get; set; }
        public string TaskOwnedbyProject { get; set; }
        public DateTime TaskCreationTime { get; set; }
        public DateOnly TaskDeliveryDate { get; set; }
        public bool TaskStatus { get; set; }
    }
}
