using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Repository
{
    public interface IClientRepository
    {
        Task<Result<Client>> CreateClient(Client client);
        Task<Result<Client>> UpdateClient(Client client);
        Task<Result<Client>> GetClient(string cpf, bool budgets);
        Task<Result<IEnumerable<Client>>> GetAllClients();
        Task<Result> DeleteClient(string cpf);
        Task<Result<Client>> GetClientWithAddress(string cpf);
    }
}
