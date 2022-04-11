using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string UserDepartment { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
    }

}
