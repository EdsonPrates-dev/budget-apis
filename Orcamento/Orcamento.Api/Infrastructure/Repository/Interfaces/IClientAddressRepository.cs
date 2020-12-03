using CSharpFunctionalExtensions;
using Orcamento.Api.Models.Entities.Address;
using System.Threading.Tasks;
using ClientsAddress = Orcamento.Api.Models.Entities.Clients.ClientsAddress;

namespace Orcamento.Api.Infrastructure.Repository
{
    public interface IClientAddressRepository
    {
        Task<Result<ClientsAddress>> CreateClientAddress(ClientsAddress clientAddress);
        Task<Result<ClientsAddress>> UpdateClientAddress(ClientsAddress ClientAddress);
        Task<Result<ClientsAddress>> GetClientAddress(int id);
        Task<Result<Address>> GetAddressFromCep(string cep);
        Task<Result> DeleteClientAddress(int id);
    }
}