using IWE.Entity.Concrete;

namespace IWE.DTO.Concrete
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string TaskAssigned { get; set; } = string.Empty;
        public string TaskName { get; set; } = string.Empty;
    }
}
