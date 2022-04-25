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

    public List<CategoryDto> GetCategories()
    {
        return Set().Select(c => new CategoryDto
        {
            Id = c.Id,
            CategoryName = c.CategoryName,
        }).ToList();
    }

    public List<CategoryWithProjects> GetCategoryWithProjects(int id)
    {
        return Set().Select(c => new CategoryWithProjects
        {

            CategoryName = c.CategoryName,

            Projects = c.Projects.Select(p => new ProjectListDto
            {
                  ProjectName = p.ProjectName,
                  ProjectOwnerName = p.WhoCreated
            }).ToList()

        }).Where(x=> x.id == id).ToList();
    }
}