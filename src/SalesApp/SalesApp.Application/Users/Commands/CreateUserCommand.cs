using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;
using SalesApp.Domain.Enums;
using SalesApp.Domain.ValueObjects;

namespace SalesApp.Application.Users.Commands
{
    public class CreateUserCommand: IRequest<Result<User>>
    {
        public string email { get; set; } = string.Empty;

        public string username { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
        public Name name { get; set; }

        public Address address { get; set; }

        public string phone { get; set; } = string.Empty;

        public UserStatus status { get; set; }

        public UserRole role { get; set; }
    }
}
