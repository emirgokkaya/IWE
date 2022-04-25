using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    List<DepartmentWithEmployees> GetDepartmentWithEmployees();
}