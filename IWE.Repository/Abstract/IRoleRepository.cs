using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IRoleRepository : IBaseRepository<Role>
{
    List<RoleDto> GetRole();
    List<RoleWithEmployees> GetRoleWithEmployees();
}