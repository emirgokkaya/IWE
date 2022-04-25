using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface ICategoryRepository : IBaseRepository<Category>
{
    List<CategoryDto> GetCategories();
    List<CategoryWithProjects> GetCategoryWithProjects(int id);
}