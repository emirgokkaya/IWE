using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class ProjectCRUD
    {
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty ;
        public bool Status { get; set; }
    }
}
