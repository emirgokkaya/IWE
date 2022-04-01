using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Department : Base
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public string DepartmentName { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; }
    }
}
