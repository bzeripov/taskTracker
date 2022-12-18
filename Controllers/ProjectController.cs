namespace project.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    ProjectService projectService = new ProjectService();
    TaskService taskService = new TaskService();

    /// <summary>
    /// Gets all projects from database.
    /// </summary>
    [HttpGet]
    public ActionResult<List<Project>> GetAll() => projectService.GetAll();

    /// <summary>
    /// Gets all projects from database with different filters.
    /// </summary>
    [HttpGet("filter={filter}")]
    public ActionResult<List<Project>> GetAllFiltered(string filter){
        List<Project> projects = new List<Project>();
        switch(filter)
        {
            case "start_date":
                projects = 
                    (from project in projectService.GetAll()
                    orderby project.StartDate
                    select project).ToList();
                break;
            case "completion_date":
                projects = 
                    (from project in projectService.GetAll()
                    orderby project.CompletionDate
                    select project).ToList();
                break;
            case "priority":
                projects = 
                    (from project in projectService.GetAll()
                    orderby project.Priority descending
                    select project).ToList();
                break;
            case "tasks_amount":
                projects = 
                    (from project in projectService.GetAll()
                    orderby (taskService.GetAllByProject(project.ProjectId)).Count descending
                    select project).ToList();
                break;
            case "task_name":
                projects = 
                    (from project in projectService.GetAll()
                    orderby project.Name
                    select project).ToList();
                break;
        }
        return projects;
    }


    /// <summary>
    /// Gets a project by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Project> Get(int Id)
    {
        var project = projectService.Get(Id);
        if(project == null) return NotFound();
        return project;
    }

    /// <summary>
    /// Gets all tasks of a project.
    /// </summary>
    [HttpGet("{id}/tasks")]
    public ActionResult<List<Task>> GetAllTasks(int id){
        var tasks = taskService.GetAllByProject(id);
        if(tasks == null) return NotFound();
        return tasks;
    }

    /// <summary>
    /// Creating a project
    /// </summary>
    [HttpPost]
    public IActionResult Create(Project project)
    {
        projectService.Create(project);
        return CreatedAtAction(nameof(Create), new {id = project.ProjectId}, project);
    }

    /// <summary>
    /// Updating existing project
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int Id, Project project)
    {
        if(Id != project.ProjectId) return BadRequest();
        var existing = projectService.Get(Id);
        if(existing == null) return NotFound();
        projectService.Update(project);
        return NoContent();
    }

    /// <summary>
    /// Deletes a project
    /// </summary>
    [HttpDelete]
    public IActionResult Delete(int Id)
    {
        var toDelete = projectService.Get(Id);
        if(toDelete is null) return NotFound();
        projectService.Delete(Id);
        return NoContent();
    }
}