using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class RoleWithEmployees
    {
        public string RoleName { get; set; } = string.Empty;
        public ICollection<UserDto>? Employees { get; set; }

    }
}
