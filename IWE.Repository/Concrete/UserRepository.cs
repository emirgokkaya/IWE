using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IWEContext context) : base(context)
    {
    }
}