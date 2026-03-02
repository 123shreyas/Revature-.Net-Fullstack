using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DtoDemo.Models;
using DtoDemo.DTOs;

namespace DtoDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> _users = new List<User>();
    private readonly IMapper _mapper;

    public UsersController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // POST: api/users
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);

        user.Id = _users.Count + 1;

        _users.Add(user);

        var response = _mapper.Map<UserResponse>(user);

        return Ok(response);
    }

    // GET: api/users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var response = _mapper.Map<List<UserResponse>>(_users);
        return Ok(response);
    }
}