using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;
using System.Text.Json.Serialization;

namespace SalesApp.Application.Carts.Commands
{
    public class CreateCartCommand: IRequest<Result<Cart>>
    {
        public int userId { get; set; }

        [JsonIgnore]
        public User? user { get; set; }

        public DateTime date { get; set; }

        public List<UseCartItemCommand> products { get; set; } = [];
    }
}
