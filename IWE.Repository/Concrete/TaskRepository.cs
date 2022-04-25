using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.DTO.Concrete;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class TaskRepository : BaseRepository<IWE.Entity.Concrete.Task>, ITaskRepository
{
    public TaskRepository(IWEContext context) : base(context)
    {
    }

    public List<TaskDto> GetTask()
    {
        return Set().Select(x => new TaskDto
        {
            Id = x.Id,
            ProjectName = x.Project.ProjectName,
            TaskAssigned = x.User.FirstName + " " + x.User.LastName,
            TaskName = x.TaskName,
        }).ToList();
    }

    public List<TaskDto> GetTaskOfProject(int id)
    {
        return Set().Where(x=> x.ProjectId == id).Select(x => new TaskDto
        {
            Id = x.Id,
            ProjectName = x.Project.ProjectName,
            TaskAssigned = x.User.FirstName + " " + x.User.LastName,
            TaskName = x.TaskName,
        }).ToList();

    }
    public List<TaskDto> GetTaskOfUser(int id)
    {
        return Set().Where(x=> x.UserId == id).Select(x => new TaskDto
        {
            Id = x.Id,
            ProjectName = x.Project.ProjectName,
            TaskAssigned = x.User.FirstName + " " + x.User.LastName,
            TaskName = x.TaskName,
        }).ToList();

    }public List<TaskDto> MyTask(int id)
    {
        return Set().Where(x=> x.UserId == id).Select(x => new TaskDto
        {
            Id = x.Id,
            ProjectName = x.Project.ProjectName,
            TaskAssigned = x.User.FirstName + " " + x.User.LastName,
            TaskName = x.TaskName,
        }).ToList();

    }
}