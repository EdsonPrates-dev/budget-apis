using FluentValidation;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Validations
{
    public class LaborBudgetValidation : AbstractValidator<LaborBudget>
    {
        public LaborBudgetValidation()
        {
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("Preço não pode ser nulo! ");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição não pode ser nula! ");
        }
    }
}
