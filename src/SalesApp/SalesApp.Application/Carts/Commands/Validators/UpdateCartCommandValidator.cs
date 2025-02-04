using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Carts.Commands.Validators
{
    internal class UpdateCartCommandValidator: AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator(ICartRepository cartRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            RuleFor(command => command.userId)
                .MustAsync(async (cmd, userId, ct) =>
                {
                    cmd.user = await userRepository.GetById(cmd.userId);
                    return cmd.user != null;
                })
                .WithMessage($"The user doesn't exists.");

            RuleFor(command => command.date)
                .MustAsync(async (cmd, date, ct) =>
                    !(await cartRepository.ExistsByUserAndDate(cmd.id, cmd.userId, cmd.date))
                 )
                .WithMessage("There is another cart with same user and date.");

            RuleForEach(command => command.products).SetValidator(new UseCartItemCommandValidator(productRepository));
        }
    }
}
