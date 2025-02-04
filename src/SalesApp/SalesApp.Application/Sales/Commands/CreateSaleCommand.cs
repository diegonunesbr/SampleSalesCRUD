using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;
using SalesApp.Domain.Enums;
using System.Text.Json.Serialization;

namespace SalesApp.Application.Sales.Commands
{
    public class CreateSaleCommand: IRequest<Result<Sale>>
    {
        public DateTime date { get; set; }

        public int userId { get; set; }

        public string branch { get; set; }

        public List<SaleItemCommand> products { get; set; } = [];

        public SaleStatus status { get; set; }



        [JsonIgnore]
        public User? user { get; set; }
    }
}
