using FluentValidation;
using Orcamento.Api.Models.Entities.Clients;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class ClientAddressValidation : AbstractValidator<ClientsAddress>
    {
        public ClientAddressValidation()
        {
            RuleFor(x => x.IdClient).NotEmpty().WithMessage("Cliente não pode ser nulo! ");
            RuleFor(x => x.Cep).NotEmpty().WithMessage("Cep não pode ser nulo! ");
            RuleFor(x => x.City).NotEmpty().WithMessage("Cidade não pode ser nula! ");
            RuleFor(x => x.Country).NotEmpty().WithMessage("País não pode ser nulo! ");
            RuleFor(x => x.Neighborhood).NotEmpty().WithMessage("Bairro não pode ser nulo! ");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Número não pode ser nulo! ");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Rua não pode ser nula! ");
        }
    }
}
