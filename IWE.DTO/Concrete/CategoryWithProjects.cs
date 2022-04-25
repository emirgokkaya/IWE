using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class CategoryWithProjects
    {
        public int id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<ProjectListDto> ?Projects { get; set; }
    }
}
