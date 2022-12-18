namespace project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum TaskStatus
{
    ToDo,
    InProgress,
    Done
}

public class Task
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; set; }
    [Required]
    public string? Name { get; set; }
    public TaskStatus CurrentStatus { get; set; } = TaskStatus.ToDo;
    public string? description { get; set; }
    
    public int Priority { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}