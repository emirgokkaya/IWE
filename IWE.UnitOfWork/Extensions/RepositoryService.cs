using IWE.Entity.Concrete;
using IWE.Repository.Abstract;
using IWE.Repository.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace IWE.UnitOfWork.Extensions;

public static class RepositoryService
{
    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUnitOfWork, Concrete.UnitOfWork>();
        
        services.AddScoped<User>();
        return services;
    }
}