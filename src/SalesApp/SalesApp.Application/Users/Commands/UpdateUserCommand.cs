using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;
using SalesApp.Domain.Enums;
using SalesApp.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace SalesApp.Application.Users.Commands
{
    public class UpdateUserCommand: IRequest<Result<User>>
    {
        [JsonIgnore]
        public int id { get; set; }
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
