using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Budget;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface ILaborBudgetService
    {
        Task<Result<LaborBudgetDTO>> CreateLaborBudget(LaborBudget laborBudget, string cpf);
        Task<Result<LaborBudgetDTO>> UpdateLaborBudget(LaborBudget laborBudget, string cpfClient);
        Task<Result<LaborBudgetDTO>> GetLaborBudget(int idClient);
        Task<Result> DeleteLaborBudget(int idClient);
    }
}