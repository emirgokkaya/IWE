using IWE.Repository.Abstract;

namespace IWE.UnitOfWork.Abstract;

public interface IUnitOfWork
{
    IAuthRepository _authRepository { get; }
    IUserRepository _userRepository { get; }
    IRoleRepository _roleRepository { get; }
    IDepartmentRepository _departmentRepository { get; }
    ICategoryRepository _categoryRepository { get; }
    ITicketRepository _ticketRepository { get; }
    IProjectRepository _projectRepository { get; }
    ITaskRepository _taskRepository { get; }

    void Save();
}