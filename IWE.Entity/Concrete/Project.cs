using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Project : Base
    {
        public Project()
        {
            Users = new HashSet<User>();
            Tasks = new HashSet<Task>();
            Categories = new HashSet<Category>();
        }

        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
