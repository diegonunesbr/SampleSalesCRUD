using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Products.Commands.Validators
{
    internal class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            RuleFor(command => command.title)
                .NotEmpty()
                .WithMessage("The title can't be empty.");

            RuleFor(command => command.price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The price can't be negative");

            RuleFor(command => command.category)
                .NotEmpty()
                .WithMessage("The category can't be empty.");

            RuleFor(command => command.title)
                .MustAsync(async (cmd, title, ct) =>
                    !(await productRepository.ExistsByTitle(cmd.id, title))
                 )
                .WithMessage("There is another product with same title.");
        }
    }
}
