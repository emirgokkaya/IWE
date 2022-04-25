using IWE.Entity.Concrete;
using IWE.Entity.Concrete.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task = IWE.Entity.Concrete.Task;

namespace IWE.DAL.Contexts;

public class IWEContext : DbContext
{
    public DbSet<User> ?Users { get; set; }
    public DbSet<Role> ?Roles { get; set; }
    public DbSet<Department> ?Departments { get; set; }
    public DbSet<Project> ?Projects { get; set; }
    public DbSet<Task> ?Tasks { get; set; }
    public DbSet<Ticket> ?Tickets { get; set; }
    public DbSet<Category> ?Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=MURAT\SQLEXPRESS;Database=IWEDatabase;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}