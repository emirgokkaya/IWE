namespace IWE.DTO.Concrete;

public class ProjectDetailDto
{
    public ProjectDetailDto()
    {
        TaskList = new HashSet<TaskDto>();
        CategoryList = new HashSet<CategoryDto>();
        UserList = new HashSet<UserDto>();
    }

    public int Id { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public ICollection<TaskDto> TaskList { get; set; }
    public ICollection<CategoryDto> CategoryList { get; set; }
    public ICollection<UserDto> UserList { get; set; }
}