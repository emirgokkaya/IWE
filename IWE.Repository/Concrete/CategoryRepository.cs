using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IWEContext context) : base(context)
    {
    }

    public IQueryable<CategoryDto> GetCategories(int id)
    {
        return Set().Select(x => new CategoryDto
        {
            Id = x.Id,
           CategoryName = x.CategoryName,
        }).Where(x => x.Id == id);
    }
}