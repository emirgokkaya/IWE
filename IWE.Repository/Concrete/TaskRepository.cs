using IWE.Core.Concrete;
using IWE.DAL.Contexts;
using IWE.Repository.Abstract;

namespace IWE.Repository.Concrete;

public class TaskRepository : BaseRepository<IWE.Entity.Concrete.Task>, ITaskRepository
{
    public TaskRepository(IWEContext context) : base(context)
    {
    }
}