using IWE.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.DTO.Concrete
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}