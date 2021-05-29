using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).NotNull().NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(25).NotNull().NotEmpty();
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).LessThan(120);
        }
    }
}
