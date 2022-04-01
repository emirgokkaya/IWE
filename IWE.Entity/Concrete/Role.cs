using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Role : Base
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string RoleName { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; }
    }
}
