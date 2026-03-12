using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[Controller]")]

public class CustomerController: ControllerBase
{
    [HttpGet]
    public IActionResult GetCustomer()
    {
        return Ok("All Customers");
    }
};