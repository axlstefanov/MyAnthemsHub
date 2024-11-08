using AutoMapper;
using MyAnthemsAPI.Management.UserManagement.Dtos;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Management.UserManagement.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}