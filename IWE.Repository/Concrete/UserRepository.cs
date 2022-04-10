using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IWEContext context) : base(context)
    {
    }

    public List<UserDto> GetUsers()
    {
        return Set().Select(x => new UserDto
        {
            Id = x.Id,
            UserDepartment=x.Department.DepartmentName,
            UserFullName=x.FirstName + " " +x.LastName,
            UserRole =x.Role.RoleName,

        }).ToList();
    }
}