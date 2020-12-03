using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Budget;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Repository
{
    public interface ILaborBudgetRepository
    {
        Task<Result<LaborBudget>> CreateLaborBudget(LaborBudget laborBudget, string cpf);
        Task<Result<LaborBudget>> UpdateLaborBudget(LaborBudget laborBudget, string cpfClient);
        Task<Result<LaborBudget>> GetLaborBudget(int idClient);
        Task<Result> DeleteLaborBudget(int idClient);
    }
}