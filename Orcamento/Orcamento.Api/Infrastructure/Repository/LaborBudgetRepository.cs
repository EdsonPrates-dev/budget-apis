using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class LaborBudgetRepository : ILaborBudgetRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;

        public LaborBudgetRepository(ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
        }

        public async Task<Result<LaborBudget>> CreateLaborBudget(LaborBudget laborBudget, string cpfClient)
        {
            laborBudget.IdClient = await _projectBudgetContext.Client.Where(c => c.Cpf == cpfClient)?.Select(s => s.IdClient).FirstOrDefaultAsync();

            if (laborBudget.IdClient == 0)
                return Result.Failure<LaborBudget>("Cliente não cadastrado na base de dados. Por favor, cadastre o cliente para efetuar um orçamento. ");

            _projectBudgetContext.LaborBudget.Add(laborBudget);
            await _projectBudgetContext.SaveChangesAsync();

            return laborBudget;
        }

        public async Task<Result> DeleteLaborBudget(int idClient)
        {
            var query =
                await (
                       from labor in _projectBudgetContext.LaborBudget
                       where labor.IdClient == idClient
                       select labor
                       )
                       .AsNoTracking()
                       .FirstOrDefaultAsync();

            if (query is null)
                return Result.Failure("Orçamento de mão de obra não existente. ");

            _projectBudgetContext.Remove(query);
            await _projectBudgetContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<LaborBudget>> GetLaborBudget(int idClient)
        {
            var result = await _projectBudgetContext.LaborBudget.FirstOrDefaultAsync(l => l.IdClient == idClient);

            if (result is null)
                return Result.Failure<LaborBudget>("Cliente não encontrado na base de dados. ");

            return result;
        }

        public async Task<Result<LaborBudget>> UpdateLaborBudget(LaborBudget laborBudget, string cpfClient)
        {
            var client = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == cpfClient);

            if (client is null)
                return Result.Failure<LaborBudget>("Cliente não cadastrado na base de dados. Por favor, cadastre o cliente para efetuar um orçamento. ");

            var laborBudgetDatabase = await _projectBudgetContext.LaborBudget
                .FirstOrDefaultAsync(c => c.IdClient == client.IdClient);

            if (laborBudgetDatabase is null)
                return Result.Failure<LaborBudget>("Orçamento de mão de obras não cadastrado para esse cliente. ");

            laborBudgetDatabase.CostPrice = laborBudget.CostPrice;
            laborBudgetDatabase.Description = laborBudget.Description;

            _projectBudgetContext.LaborBudget.Update(laborBudgetDatabase);
            await _projectBudgetContext.SaveChangesAsync();

            return laborBudgetDatabase;
        }

    }
}
