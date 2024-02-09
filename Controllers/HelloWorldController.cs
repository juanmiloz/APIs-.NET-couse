using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Services.ServiceImpl;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    private IHelloWorldService helloWorldService;
    private TaskContext dbContext;

    public HelloWorldController(IHelloWorldService helloWorldService,TaskContext taskContext, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        dbContext = taskContext;
        this.helloWorldService = helloWorldService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando un status OK, con hello world");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    } 
}