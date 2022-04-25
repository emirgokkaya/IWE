using IWE.Core.Abstract;
using IWE.DTO.Concrete;
using Task = IWE.Entity.Concrete.Task;

namespace IWE.Repository.Abstract;

public interface ITaskRepository : IBaseRepository<Task>
{
    List<TaskDto> GetTask();
    List<TaskDto> GetTaskOfProject(int id);
    List<TaskDto> GetTaskOfUser(int id);
    List<TaskDto> MyTask(int id);
}