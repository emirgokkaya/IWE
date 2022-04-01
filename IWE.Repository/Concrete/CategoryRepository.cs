using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IWEContext context) : base(context)
    {
    }
}