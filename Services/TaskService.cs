using project.Models;
using project.Context;
namespace project.Services;
using Task_ = project.Models.Task;

public class TaskService
{
    public ApplicationContext context = new ApplicationContext();

    public List<Task_> GetAll() => context.Tasks.ToList();

    public Task_ Get(int Id) => context.Tasks.Find(Id);

    public void Create(Task_ task)
    {
        context.Tasks.Add(task);
        context.SaveChanges();
    }

    public List<Task_> GetAllByProject(int id){
        var tasks = 
            from task in GetAll()
            where task.ProjectId == id
            select task;
        return tasks.ToList();
    }

    public void Update(Task_ task)
    {
        Task_ crnt = Get(task.ProjectId);
        crnt.Name = task.Name;
        crnt.CurrentStatus = task.CurrentStatus;
        crnt.Priority = task.Priority;
        crnt.description = task.description;
        crnt.Project = task.Project;
        crnt.ProjectId = task.ProjectId;
        context.Tasks.Update(crnt);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        Task_ task = Get(Id);
        if (task != null){
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
        return;
    }
}