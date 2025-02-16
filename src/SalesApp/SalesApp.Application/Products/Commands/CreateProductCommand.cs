﻿using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;
using SalesApp.Domain.ValueObjects;

namespace SalesApp.Application.Products.Commands
{
    public class CreateProductCommand: IRequest<Result<Product>>
    {
        public string title { get; set; } = string.Empty;

        public decimal price { get; set; }

        public string? description { get; set; } = string.Empty;

        public string category { get; set; } = string.Empty;

        public string? image { get; set; } = string.Empty;

        public Rating rating { get; set; }
    }
}
