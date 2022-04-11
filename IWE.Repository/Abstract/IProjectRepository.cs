using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IProjectRepository : IBaseRepository<Project>
{
    List<ProjectListDto> GetProjects();
    List<ProjectListDto> GetProjectsOfUser(string authUser);
    List<ProjectDetailDto> GetProjectDetail(int id);
}