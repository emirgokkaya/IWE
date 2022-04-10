using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IUserRepository : IBaseRepository<User>
{
    List<UserDto> GetUsers();
}