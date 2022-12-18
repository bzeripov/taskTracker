using project.Models;
using project.Context;
namespace project.Services;
using Task_ = project.Models.Task;

public class ProjectService
{
    public ApplicationContext context = new ApplicationContext();

    public List<Project> GetAll() => context.Projects.ToList();

    public Project Get(int Id) => context.Projects.Find(Id);

    public void Create(Project project)
    {
        context.Projects.Add(project);
        context.SaveChanges();
    }

    public void Update(Project project)
    {
        Project crnt = Get(project.ProjectId);
        crnt.Name = project.Name;
        crnt.CurrentStatus = project.CurrentStatus;
        crnt.StartDate = project.StartDate;
        crnt.CompletionDate = project.CompletionDate;
        crnt.Tasks = project.Tasks;
        crnt.Priority = project.Priority;
        context.Projects.Update(crnt);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        Project project = Get(Id);
        if (project != null){
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }

}