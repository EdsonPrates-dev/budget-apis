using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class MaterialsBudgetRepository : IMaterialsBudgetRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;

        public MaterialsBudgetRepository(ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
        }

        public async Task<Result<MaterialsBudget>> CreateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient)
        {
            var clientId = await _projectBudgetContext.Client.Where(c => c.Cpf == cpfClient)?.Select(s => s.IdClient).FirstOrDefaultAsync();

            if (clientId == 0)
                return Result.Failure<MaterialsBudget>("Cliente não cadastrado na base de dados. Por favor, cadastre o cliente para efetuar um orçamento. ");

            materialsBudget.IdClient = clientId;
            _projectBudgetContext.MaterialsBudget.Add(materialsBudget);
            await _projectBudgetContext.SaveChangesAsync();

            return materialsBudget;
        }

        public async Task<Result> DeleteMaterialsBudget(int idClient)
        {
            var query =
                await (
                       from materials in _projectBudgetContext.MaterialsBudget
                       where materials.IdClient == idClient
                       select materials
                       )
                       .AsNoTracking()
                       .FirstOrDefaultAsync();

            if (query is null)
                return Result.Failure("Orçamento de materiais não existente. ");

            _projectBudgetContext.Remove(query);
            await _projectBudgetContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<MaterialsBudget>> GetMaterialsBudget(int idClient)
        {
            var result = await _projectBudgetContext.MaterialsBudget.FirstOrDefaultAsync(m => m.IdClient == idClient);

            if (result is null)
                return Result.Failure<MaterialsBudget>("Orçamento de materiais não existente. ");

            return result;
        }


        public async Task<Result<MaterialsBudget>> UpdateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient)
        {
            var client = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == cpfClient);

            if (client is null)
                return Result.Failure<MaterialsBudget>("Cliente não cadastrado na base de dados. Por favor, cadastre o cliente para efetuar um orçamento. ");

            var materialsBudgetDatabase = await _projectBudgetContext.MaterialsBudget
                .FirstOrDefaultAsync(c => c.IdClient == client.IdClient);

            if (materialsBudgetDatabase is null)
                return Result.Failure<MaterialsBudget>("Orçamento de materiais não cadastrado para esse cliente. ");

            materialsBudgetDatabase.CostPrice = materialsBudget.CostPrice;
            materialsBudgetDatabase.Description = materialsBudget.Description;

            _projectBudgetContext.MaterialsBudget.Update(materialsBudgetDatabase);
            await _projectBudgetContext.SaveChangesAsync();

            return materialsBudgetDatabase;
        }
    }
}
