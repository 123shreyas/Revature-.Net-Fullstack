using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly IMapper mapper;
    private readonly IMemoryCache cache;

    public CustomerController(ICustomerService customerService, IMapper mapper, IMemoryCache cache)
    {
        this.customerService = customerService;
        this.mapper = mapper;
        this.cache = cache;
    }

    [HttpGet]
    public IActionResult Get()
    {
        string cacheKey = "customerList";

        if (!cache.TryGetValue(cacheKey, out List<CustomerDTO> customerDTOs))
        {
            var customers = customerService.GetAllCustomers();

            customerDTOs = mapper.Map<List<CustomerDTO>>(customers);

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            cache.Set(cacheKey, customerDTOs, cacheOptions);
        }

        return Ok(customerDTOs);
    }
}