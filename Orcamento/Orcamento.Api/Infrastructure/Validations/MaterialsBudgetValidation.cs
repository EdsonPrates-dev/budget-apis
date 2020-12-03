using FluentValidation;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class MaterialsBudgetValidation : AbstractValidator<MaterialsBudget>
    {
        public MaterialsBudgetValidation()
        {
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("Preço não pode ser nulo! ");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição não pode ser nula! ");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantidade não pode ser nula! ");
        }
    }
}
