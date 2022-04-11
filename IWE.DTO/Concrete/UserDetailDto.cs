using IWE.Entity.Concrete;

namespace IWE.DTO.Concrete;

public class UserDetailDto
{
    public UserDetailDto()
    {
        Projects = new HashSet<Project>();
        Tasks = new HashSet<IWE.Entity.Concrete.Task>();
        Tickets = new HashSet<Ticket>();
    }
    public User user { get; set; }
    public Department Department { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<IWE.Entity.Concrete.Task> Tasks { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}