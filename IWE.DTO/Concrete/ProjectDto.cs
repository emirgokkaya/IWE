using IWE.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class ProjectDto
    {
        public Project project { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public dynamic ProjectCategoryName { get; set; } = string.Empty;    
        public dynamic ProjectOwnerName { get; set; }
        public dynamic ProjectCompanyName { get; set; }
        public dynamic ProjectDeveloperName { get; set; }
      


    }
}
