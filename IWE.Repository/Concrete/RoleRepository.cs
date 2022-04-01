using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(IWEContext context) : base(context)
    {
    }
}