using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorldService)
    {
        this.helloWorldService = helloWorldService;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}