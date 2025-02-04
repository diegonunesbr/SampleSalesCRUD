using FluentValidation;
using SalesApp.Application.Interfaces;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Commands.Validators
{
    internal class UseCartItemCommandValidator: AbstractValidator<UseCartItemCommand>
    {
        public UseCartItemCommandValidator(IProductRepository productRepository)
        {
            RuleFor(command => command.quantity)
                .InclusiveBetween(1, 20)
                .WithMessage("Quantity must be between 1 and 20");

            RuleFor(command => command.productId)
                .MustAsync(async (cmd, productId, ct) =>
                {
                    cmd.product = await productRepository.GetById(cmd.productId);
                    return cmd.product != null;
                })
                .WithMessage($"The product doesn't exists.");
        }
    }
}
