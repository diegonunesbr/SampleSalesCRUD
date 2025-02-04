using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Sales.Commands.Validators
{
    internal class SaleItemCommandValidator: AbstractValidator<SaleItemCommand>
    {
        public SaleItemCommandValidator(IProductRepository productRepository)
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
