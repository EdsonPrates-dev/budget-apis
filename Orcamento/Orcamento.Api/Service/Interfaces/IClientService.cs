using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Models.Entities.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface IClientService
    {
        Task<Result<ClientDTO>> CreateClient(Client client);
        Task<Result<ClientDTO>> UpdateClient(Client client);
        Task<Result<ClientDTO>> GetClient(string id, bool budgets);
        Task<Result<IEnumerable<ClientDTO>>> GetAllClients();
        Task<Result> DeleteClient(string cpf);
        Task<Result<ClientDTO>> GetClientWithAddress(string cpf);
    }
}