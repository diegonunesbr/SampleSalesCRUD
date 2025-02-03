using AutoMapper;
using SalesApp.Application.Carts.Commands;
using SalesApp.Application.Products.Commands;
using SalesApp.Application.Users.Commands;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<UpdateCartCommand, Cart>();
            CreateMap<UseCartItemCommand, CartItem>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
