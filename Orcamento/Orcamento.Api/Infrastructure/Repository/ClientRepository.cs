using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.Entities.Clients;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;

        public ClientRepository(ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
        }

        public async Task<Result<Client>> CreateClient(Client client)
        {
            var result = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == client.Cpf);

            if (result != null)
                return Result.Failure<Client>("Cliente já está cadastrado! ");

            _projectBudgetContext.Client.Add(client);
            await _projectBudgetContext.SaveChangesAsync();

            return client;
        }

        public async Task<Result> DeleteClient(string cpf)
        {
            var clientDatabase =
                await (
                       from client in _projectBudgetContext.Client
                       where client.Cpf == cpf
                       select client
                       )
                       .AsNoTracking()
                       .ToListAsync();

            if (clientDatabase.Count() == 0)
                return Result.Failure("Esse cliente não está cadastrado nas bases de dados. ");

            await Task.WhenAll(
                clientDatabase.Select(client => client.IdClient)
                .Select(async (id) =>
                {
                    await DeleteClientAddress(id);
                    await DeleteLaborBudget(id);
                    await DeleteMaterialsBudget(id);
                }));

            _projectBudgetContext.RemoveRange(clientDatabase);
            await _projectBudgetContext.SaveChangesAsync();

            return Result.Success();
        }

        private async Task DeleteMaterialsBudget(int idClient)
        {
            var queryMaterialsBudget =
               await (
                       from materialsBudget in _projectBudgetContext.MaterialsBudget
                       where materialsBudget.IdClient == idClient
                       select materialsBudget
                       )
                       .AsNoTracking()
                       .FirstOrDefaultAsync();

            if (queryMaterialsBudget is null)
                return;

            _projectBudgetContext.Remove(queryMaterialsBudget);
            await _projectBudgetContext.SaveChangesAsync();
        }

        private async Task DeleteLaborBudget(int idClient)
        {
            var queryLaborBudget =
               await (
                       from laborBudget in _projectBudgetContext.LaborBudget
                       where laborBudget.IdClient == idClient
                       select laborBudget
                       )
                       .AsNoTracking()
                       .FirstOrDefaultAsync();

            if (queryLaborBudget is null)
                return;

            _projectBudgetContext.Remove(queryLaborBudget);
            await _projectBudgetContext.SaveChangesAsync();
        }

        private async Task DeleteClientAddress(int idClient)
        {
            var queryClientAddress =
                await (
                        from clientAddress in _projectBudgetContext.ClientAddress
                        where clientAddress.IdClient == idClient
                        select clientAddress
                        )
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            if (queryClientAddress is null)
                return;

            _projectBudgetContext.Remove(queryClientAddress);
            await _projectBudgetContext.SaveChangesAsync();

        }

        public async Task<Result<IEnumerable<Client>>> GetAllClients()
        {
            var client = await _projectBudgetContext.Client.ToListAsync();

            if(!client.Any())
                return Result.Failure<IEnumerable<Client>>("Não existe nenhum cliente cadastrado na base de dados. ");

            return client;
        }       

        public async Task<Result<Client>> GetClient(string cpf, bool budgets)
        {
            if (!budgets)
                return await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == cpf);

            var clientId = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == cpf);

            if (clientId != null)
                return Result.Failure<Client>("Esse cliente não está cadastrado nas bases de dados. ");

            var query =
                await (
                        from client in _projectBudgetContext.Client
                        join clientAddress in _projectBudgetContext.ClientAddress
                        on client.IdClient equals clientAddress.IdClient
                        join laborBudget in _projectBudgetContext.LaborBudget
                        on client.IdClient equals laborBudget.IdClient
                        join materialsBudget in _projectBudgetContext.MaterialsBudget
                        on client.IdClient equals materialsBudget.IdClient
                        where client.Cpf == cpf
                        select new
                        {
                            Client = client,
                            ClientAddress = clientAddress,
                            LaborBudget = laborBudget,
                            MaterialsBudget = materialsBudget
                        }
                      )
                      .AsNoTracking()
                      .FirstOrDefaultAsync();

            query.Client.MapClientAddress(query.ClientAddress,
                query.LaborBudget, query.MaterialsBudget);

            return query.Client;
        }

        public async Task<Result<Client>> UpdateClient(Client client)
        {
            var clientDatabase = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == client.Cpf);

            if (clientDatabase is null)
                return Result.Failure<Client>("Esse cliente não está cadastrado nas bases de dados. ");

            clientDatabase.Cpf = client.Cpf;
            clientDatabase.Email = client.Email;
            clientDatabase.Name = client.Name;
            clientDatabase.Phone = client.Phone;

            _projectBudgetContext.Client.Update(clientDatabase);
            await _projectBudgetContext.SaveChangesAsync();

            return client;
        }

        public async Task<Result<Client>> GetClientWithAddress(string cpf)
        {
            var clientId = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.Cpf == cpf);

            if (clientId is null)
                return Result.Failure<Client>("Esse cliente não está cadastrado nas bases de dados. ");

            var query =
                await (
                          from client in _projectBudgetContext.Client
                          join clientAddress in _projectBudgetContext.ClientAddress
                          on client.IdClient equals clientAddress.IdClient
                          where client.Cpf == cpf
                          select new
                          {
                              Client = client,
                              ClientAddress = clientAddress
                          }
                        )
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            if (query is null)
                return Result.Failure<Client>("O endereço desse cliente não está cadastrado. ");

            query.Client.MapClientAddress(query.ClientAddress);

            return query.Client;
        }
    }
}
