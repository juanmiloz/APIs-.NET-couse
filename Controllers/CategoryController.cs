using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoryService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        _categoryService.Save(category);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Category category)
    {
        _categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete( Guid id)
    {
        _categoryService.Delete(id);
        return Ok();
    }
}