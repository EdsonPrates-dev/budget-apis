using FluentValidation;
using Orcamento.Api.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Login não pode ser nulo! ");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Login não pode ser nulo! ");
        }
    }
}
