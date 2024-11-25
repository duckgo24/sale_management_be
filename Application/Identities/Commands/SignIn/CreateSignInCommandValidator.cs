using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Identities.Commands.SignIn
{
    public class CreateSignInCommandValidator : AbstractValidator<CreateSignInCommand>
    {
        public CreateSignInCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .NotNull().WithMessage("Username not null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password not null");
        }
    }
}