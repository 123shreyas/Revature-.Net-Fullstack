using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("New");
    }


    [HttpPost]
    public IActionResult CreateNew()
    {
        return Ok("All post are created");
    }
}
