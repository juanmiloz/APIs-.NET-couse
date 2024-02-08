using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    private IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        this.helloWorldService = helloWorldService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando un status OK, con hello world");
        return Ok(helloWorldService.GetHelloWorld());
    }
}