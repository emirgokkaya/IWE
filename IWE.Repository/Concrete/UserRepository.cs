using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;
using System.Security.Claims;

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
            UserEmail = x.Email,
        }).ToList();
    }

    public bool StatusChange(int id)
    {
        User ?user = Set().Find(id);
        if (user != null)
        {
            user.Status = !user.Status;
            return true;
        }
        return false;
    }

    public bool SoftDeleteUser(int id)
    {
        User? user = Set().Find(id);
        if (user != null && user.Status != true)
        {
            user.IsDeleted = true;
            return true;
        }
        return false;
    }

}