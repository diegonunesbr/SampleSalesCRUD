using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SalesApp.Application.Carts.Commands;
using SalesApp.Application.Carts.Commands.Validators;
using SalesApp.Application.Products.Commands;
using SalesApp.Application.Products.Commands.Validators;
using SalesApp.Application.Sales.Commands;
using SalesApp.Application.Sales.Commands.Validators;
using SalesApp.Application.Users.Commands;
using SalesApp.Application.Users.Commands.Validators;

namespace SalesApp.Application.Configuration
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IValidator<CreateCartCommand>, CreateCartCommandValidator>();
            services.AddTransient<IValidator<UpdateCartCommand>, UpdateCartCommandValidator>();
            services.AddTransient<IValidator<UseCartItemCommand>, UseCartItemCommandValidator>();

            services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
            services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();

            services.AddTransient<IValidator<CreateSaleCommand>, CreateSaleCommandValidator>();
            services.AddTransient<IValidator<UpdateSaleCommand>, UpdateSaleCommandValidator>();
            services.AddTransient<IValidator<SaleItemCommand>, SaleItemCommandValidator>();

            services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();

            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationDI).Assembly));


            return services;
        }
    }
}
