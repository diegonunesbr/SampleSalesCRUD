using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Sales.Commands.Validators
{
    internal class CreateSaleCommandValidator: AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            RuleFor(command => command.userId)
                .MustAsync(async (cmd, userId, ct) =>
                {
                    cmd.user = await userRepository.GetById(cmd.userId);
                    return cmd.user != null;
                })
                .WithMessage($"The user doesn't exists.");


            RuleForEach(command => command.products).SetValidator(new SaleItemCommandValidator(productRepository));
            
            RuleFor(command => command.branch)
                .NotEmpty()
                .WithMessage("The branch can't be empty.");
        }
    }
}
