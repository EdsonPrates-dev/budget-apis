using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Budget;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface IMaterialsBudgetService
    {
        Task<Result<MaterialsBudgetDTO>> CreateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient);
        Task<Result<MaterialsBudgetDTO>> UpdateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient);
        Task<Result<MaterialsBudgetDTO>> GetMaterialsBudget(int idClient);
        Task<Result> DeleteMaterialsBudget(int idClient);
    }
}