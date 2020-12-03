using FluentValidation;
using Orcamento.Api.Models.Entities.Clients;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser nulo! ");
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("Cpf não pode ser nulo! ");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefone não pode ser nulo! ");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email não pode ser nulo! ");
        }
    }
}
