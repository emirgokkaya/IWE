using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(IWEContext context) : base(context)
    {
    }

    public List<RoleDto> GetRole()
    {
        return Set().Select(x => new RoleDto
        {
            RoleName = x.RoleName
            
            
        }).ToList();
    }

    public List<RoleWithEmployees> GetRoleWithEmployees()
    {
       return Set().Select(x=> new RoleWithEmployees
       {
           RoleName = x.RoleName,
           Employees = x.Users.Select(u=> new UserDto
           {
               UserFullName = u.FirstName + " " + u.LastName,
               UserEmail = u.Email,
               
           }).ToList()
       }).ToList();
    }
}