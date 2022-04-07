using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public string ProjectCatergory { get; set; }
        public string ProjectBondedTasks { get; set; }
        public string ProjectCreator { get; set; }
        public string ProjectDevelopers { get; set; }
        public DateTime ProjectCreationTime { get; set; }
        public DateOnly ProjectDeliveryDate { get; set; }
        public bool ProjectStatus { get; set; }
    }
}
