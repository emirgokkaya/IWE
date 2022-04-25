using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(IWEContext context) : base(context)
    {
    }

    public List<DepartmentWithEmployees> GetDepartmentWithEmployees()
    {
        return Set().Select(x=> new DepartmentWithEmployees
        {
            DepartmentName = x.DepartmentName,
            Employees = x.Users.Select(u=> new UserDto
            {
                UserFullName = u.FirstName + " " + u.LastName,
                
            }).ToList()

        }).ToList();
    }
}