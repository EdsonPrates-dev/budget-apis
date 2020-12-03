using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.User;
using Orcamento.Api.Service;
using System;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;

        public UserRepository(ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
        }

        public async Task<Result<User>> GetUser(User user)
        {
            var result = await _projectBudgetContext.User
                .FirstOrDefaultAsync(u => u.Login == user.Login &&
                                          u.Password == user.Password);

            if (result is null)
                return Result.Failure<User>("Usuário ou senha inválidos");

            return result;
        }         

        public async Task CreateLoginFromContractor(User user, string cpfContractor)
        {
            var contractor = await _projectBudgetContext.Contractor
                .FirstOrDefaultAsync(c => c.Cpf == cpfContractor);

            user.IdContractor = contractor.IdContractor;

            if (contractor is null)
                throw new Exception("Não é possivel criar um login para um empreiteiro não cadastrado! ");

            _projectBudgetContext.User.Add(user);
            await _projectBudgetContext.SaveChangesAsync();
        }
    }
}
