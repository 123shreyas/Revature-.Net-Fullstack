using AutoMapper;
using DtoDemo.Models;
using DtoDemo.DTOs;

namespace DtoDemo.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}