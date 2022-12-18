namespace project.Controllers;

using Models;
using Microsoft.AspNetCore.Mvc;
using Services;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    public TaskService taskService = new TaskService();

    /// <summary>
    /// Gets all tasks from database.
    /// </summary>
    [HttpGet]
    public ActionResult<List<Task>> GetAll() => taskService.GetAll();

    /// <summary>
    /// Gets a task by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Task> Get(int Id)
    {
        var task = taskService.Get(Id);
        if (task == null) return NotFound();
        return task;
    }

    /// <summary>
    /// Creates a task
    /// </summary>
    [HttpPost]
    public IActionResult Create(Task task)
    {
        taskService.Create(task);
        return CreatedAtAction(nameof(Create), new {id = task.TaskId}, task);
    }

    /// <summary>
    /// Updates a task
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int Id, Task task)
    {
        if(Id != task.TaskId)  return BadRequest();
        var existing = taskService.Get(Id);
        if(existing is null) return NotFound();
        taskService.Update(task);
        return NoContent();
    }

    /// <summary>
    /// Deletes the task
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int Id)
    {
        var toDelete = taskService.Get(Id);
        if (toDelete is null) return NotFound();
        taskService.Delete(Id);
        return NoContent();
    }


}