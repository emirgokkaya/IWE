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

    public List<ProjectListDto> GetProjects()
    {
        return Set().Select(x => new ProjectListDto()
        {
            Id = x.Id,
            ProjectName = x.ProjectName,
            ProjectOwnerName = x.WhoCreated
        }).ToList();
    }

    public List<ProjectListDto> GetProjectsOfUser(string authUser)
    {
        return Set().Where(x => x.WhoCreated == authUser).Select(p => new ProjectListDto
        {
            Id = p.Id,
            ProjectName = p.ProjectName,
            ProjectOwnerName = p.WhoCreated
        }).ToList();
    }

    public List<ProjectDetailDto> GetProjectDetail(int id)
    {
        return Set().Select(x => new ProjectDetailDto
        {
            Id = x.Id,
            ProjectName = x.ProjectName,
            
            CategoryList = x.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            }).ToList(),
            
            TaskList = x.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                TaskName = t.TaskName
            }).ToList(),
            
            UserList = x.Users.Select(u => new UserDto
            {
                Id = u.Id,
                UserDepartment = u.Department.DepartmentName,
                UserEmail = u.Email,
                UserRole = u.Role.RoleName,
                UserFullName = u.FirstName + " " + u.LastName
            }).ToList()
        }).ToList();
    }
}