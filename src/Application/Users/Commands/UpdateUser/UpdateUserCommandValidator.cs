using Application.Users.Commands.GetUser;
using FluentValidation;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).NotNull().NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(25).NotNull().NotEmpty();
            RuleFor(x => x.Age).GreaterThan(18).LessThan(120);
        }
    }
}
