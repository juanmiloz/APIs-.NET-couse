using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using Task = webapi.Model.Task;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase

{
    private ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService; 
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_taskService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Task task)
    {
        _taskService.Save(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Task task, Guid id)
    {
        _taskService.Update(task, id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _taskService.Delete(id);
        return Ok();
    }

}