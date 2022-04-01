using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Category : Base
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }

        public string CategoryName { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; }
    }
}
