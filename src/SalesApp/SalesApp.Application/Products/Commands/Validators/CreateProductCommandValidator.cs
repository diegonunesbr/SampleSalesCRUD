using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Products.Commands.Validators
{
    internal class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(IProductRepository productRepository)
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
                    !(await productRepository.ExistsByTitle(0, title))
                 )
                .WithMessage("There is another product with same title.");
        }
    }
}
