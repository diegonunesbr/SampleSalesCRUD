﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SalesApp.Application.Users.Commands;
using SalesApp.Application.Users.Commands.Validators;

namespace SalesApp.Application.Configuration
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();

            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationDI).Assembly));


            return services;
        }
    }
}
