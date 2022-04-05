using IWE.DAL.Contexts;
using IWE.Repository.Abstract;
using IWE.UnitOfWork.Abstract;

namespace IWE.UnitOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly IWEContext _context;
    public IUserRepository _userRepository { get; }
    public IRoleRepository _roleRepository { get; }
    public IDepartmentRepository _departmentRepository { get; }
    public ICategoryRepository _categoryRepository { get; }
    public ITicketRepository _ticketRepository { get; }
    public IProjectRepository _projectRepository { get; }
    public ITaskRepository _taskRepository { get; }
    public IAuthRepository _authRepository { get; }

    public UnitOfWork(IWEContext context, IUserRepository userRepository, IRoleRepository roleRepository, IDepartmentRepository departmentRepository, ICategoryRepository categoryRepository, ITicketRepository ticketRepository, IProjectRepository projectRepository, ITaskRepository taskRepository, IAuthRepository authRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _departmentRepository = departmentRepository;
        _categoryRepository = categoryRepository;
        _ticketRepository = ticketRepository;
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
        _authRepository = authRepository;
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}