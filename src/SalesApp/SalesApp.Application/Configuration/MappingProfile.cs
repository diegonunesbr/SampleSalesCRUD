using AutoMapper;
using SalesApp.Application.Users.Commands;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
