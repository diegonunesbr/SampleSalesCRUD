using FluentValidation;
using SalesApp.Application.Interfaces;

namespace SalesApp.Application.Users.Commands.Validators
{
    internal class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(command => command.email)
                .NotEmpty()
                .WithMessage("The e-mail can't be empty.");

            RuleFor(command => command.email)
                .EmailAddress()
                .WithMessage("Invalid e-mail address");

            RuleFor(command => command.username)
                .NotEmpty()
                .WithMessage("The username can't be empty.");

            RuleFor(command => command.password)
                .MinimumLength(8)
                .WithMessage("The password must have at least 8 characters.");

            RuleFor(command => command.name)
                .NotNull()
                .WithMessage("Name must be filled.");

            RuleFor(command => command.name.firstname)
                .NotEmpty()
                .WithMessage("First name can't be empty.");

            RuleFor(command => command.name.lastname)
                .NotEmpty()
                .WithMessage("Last name can't be empty.");

            RuleFor(command => command.address)
                .NotNull()
                .WithMessage("Address must be filled.");

            RuleFor(command => command.address.city)
                .NotEmpty()
                .WithMessage("City can't be empty.");

            RuleFor(command => command.address.street)
                .NotEmpty()
                .WithMessage("Street can't be empty.");

            RuleFor(command => command.address.zipcode)
                .NotEmpty()
                .WithMessage("Zipcode can't be empty.");

            RuleFor(command => command.phone)
                .NotEmpty()
                .WithMessage("The phone can't be empty.");

            RuleFor(command => command.username)
                .MustAsync(async (cmd, username, ct) =>
                    !(await userRepository.ExistsByUserName(0, username))
                 )
                .WithMessage("There is another user with same username.");

            RuleFor(command => command.email)
                .MustAsync(async (cmd, email, ct) =>
                    !(await userRepository.ExistsByEmail(0, email))
                 )
                .WithMessage("There is another user with same e-mail.");
        }
    }
}
