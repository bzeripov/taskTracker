namespace project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Status{
    NotStarted,
    Active,
    Completed
}

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }
    [Required]
    public string? Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? CompletionDate { get; set; }
    public Status CurrentStatus { get; set; } = Status.NotStarted;
    [Required]
    public int Priority { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
}