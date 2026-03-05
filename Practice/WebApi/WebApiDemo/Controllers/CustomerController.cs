using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    ICustomerService customerService;
    IMapper mapper;
    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        this.customerService = customerService;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var customers = customerService.GetAllCustomers();

        var customerDTOs = mapper.Map<List<CustomerDTO>>(customers);

        return Ok(customerDTOs);
    }
}