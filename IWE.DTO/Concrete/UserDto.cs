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
        public string UserFullName { get; set; }
        public string UserRole { get; set; }
        public string UserDepartment { get; set; }
        public string UserAdress { get; set; }
        public string UserEmail { get; set; }
    }

}
