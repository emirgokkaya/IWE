using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(IWEContext context) : base(context)
    {
    }

    public List<ProjectDto> GetProjects(int id)
    {
        return Set().Select(x => new ProjectDto
        {
            ProjectName = x.ProjectName,
            ProjectCompanyName =x.Users.Where(x => x.Id == id).FirstOrDefault(),
            ProjectCategoryName = x.Users.Where(x => x.Id == id).FirstOrDefault(),
            ProjectDeveloperName = x.Users.Where(x => x.Id == id).FirstOrDefault(),
            ProjectOwnerName=x.Users.Where(x => x.Id == id).FirstOrDefault(),
            

        }).ToList();
    }
}