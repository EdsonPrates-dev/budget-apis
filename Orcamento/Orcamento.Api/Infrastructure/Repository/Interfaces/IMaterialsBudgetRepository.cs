using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Budget;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Repository
{
    public interface IMaterialsBudgetRepository
    {
        Task<Result<MaterialsBudget>> CreateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient);
        Task<Result<MaterialsBudget>> UpdateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient);
        Task<Result<MaterialsBudget>> GetMaterialsBudget(int idClient);
        Task<Result> DeleteMaterialsBudget(int idClient);
    }
}