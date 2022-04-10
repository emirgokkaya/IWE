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
            TaskName = x.TaskName,
            TaskCreationTime =x.CreatedAt,
            TaskStatus = x.Status,
            

        }).ToList();
    }
}