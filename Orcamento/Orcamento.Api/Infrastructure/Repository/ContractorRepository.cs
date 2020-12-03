using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.Entities.Contractors;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;

        public ContractorRepository(ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
        }

        public async Task<Result<Contractor>> CreateContractor(Contractor contractor)
        {
            var contractorDatabase = await _projectBudgetContext.Contractor.FirstOrDefaultAsync(c => c.Cpf == contractor.Cpf);

            if (contractorDatabase != null)
                return Result.Failure<Contractor>("Este empreiteiro já está cadastrado na base de dados. ");

            _projectBudgetContext.Contractor.Add(contractor);
            await _projectBudgetContext.SaveChangesAsync();

            return contractor;
        }

        public async Task<Result> DeleteContractor(string cpf)
        {
            var query =
                 await (
                        from contractor in _projectBudgetContext.Contractor
                        where contractor.Cpf == cpf
                        select contractor
                        )
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            if (query is null)
                return Result.Failure("Empreiteiro não está cadastrado. ");

            await DeleteLogin(query.IdContractor);

            _projectBudgetContext.Remove(query);
            await _projectBudgetContext.SaveChangesAsync();

            return Result.Success();
        }

        private async Task DeleteLogin(int idContractor)
        {
            var query =
                await (
                       from user in _projectBudgetContext.User
                       where user.IdContractor == idContractor
                       select user
                       )
                       .AsNoTracking()
                       .FirstOrDefaultAsync();

            if (query is null)
                return;

            _projectBudgetContext.Remove(query);
            await _projectBudgetContext.SaveChangesAsync();
        }

        public async Task<Result<Contractor>> GetContractor(int id)
        {
            var contractor = await _projectBudgetContext.Contractor.FirstOrDefaultAsync(c => c.IdContractor == id);

            if (contractor is null)
                return Result.Failure<Contractor>("Não foi possível encontrar esse empreiteiro cadastrado na base de dados. ");

            return contractor;
        }     

        public async Task<Result<Contractor>> UpdateContractor(Contractor contractor)
        {
            var contractorDatabase = await _projectBudgetContext.Contractor.FirstOrDefaultAsync(c => c.Cpf == contractor.Cpf);

            if (contractorDatabase is null)
                return Result.Failure<Contractor>("Este empreiteiro não está cadastrado na base de dados. ");

            contractorDatabase.Cpf = contractor.Cpf;
            contractorDatabase.Name = contractor.Name;
            contractorDatabase.Phone = contractor.Phone;

            _projectBudgetContext.Contractor.Update(contractorDatabase);
            await _projectBudgetContext.SaveChangesAsync();
            return contractorDatabase;
        }
    }
}
