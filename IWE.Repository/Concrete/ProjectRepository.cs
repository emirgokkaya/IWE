using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(IWEContext context) : base(context)
    {
    }
}