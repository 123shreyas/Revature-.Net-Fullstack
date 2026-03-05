using AutoMapper;
using DataAccessLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly IMapper mapper;
    private readonly IValidator<CreateCustomerDTO> createCustomerDTOValidator;

    public CustomerController(
        ICustomerService customerService,
        IMapper mapper,
        IValidator<CreateCustomerDTO> createCustomerDTOValidator)
    {
        this.customerService = customerService;
        this.mapper = mapper;
        this.createCustomerDTOValidator = createCustomerDTOValidator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var customers = customerService.GetAllCustomers();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get([FromRoute] int id)
    {
        var customers = customerService.GetAllCustomers().ToList();

        var customerDTOs = mapper.Map<List<CustomerDTO>>(customers);

        return Ok(customerDTOs);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateCustomerDTO createCustomerDTO)
    {
        var validationResult = createCustomerDTOValidator.Validate(createCustomerDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        return Ok(createCustomerDTO);
    }
}