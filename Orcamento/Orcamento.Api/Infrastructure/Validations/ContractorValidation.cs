using FluentValidation;
using Orcamento.Api.Models.Entities.Contractors;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class ContractorValidation : AbstractValidator<Contractor>
    {
        public ContractorValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser nulo! ");
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("Cpf não pode ser nulo! ");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefone não pode ser nulo! ");
        }
    }
}
