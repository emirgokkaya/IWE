using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IProjectRepository : IBaseRepository<Project>
{
    List<ProjectDto> GetProjects(int id);
}