using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Client;
using Orcamento.Api.Models.Entities.Clients;
using System.Threading.Tasks;

namespace Orcamento.Api.Service.Interfaces
{
    public interface IClientAddressService
    {
        Task<Result<ClientAddressDTO>> CreateClientAddress(ClientsAddress clientAddress);
        Task<Result<ClientAddressDTO>> UpdateClientAddress(ClientsAddress ClientAddress);
        Task<Result<ClientAddressDTO>> GetClientAddress(int id);
        Task<Result<ClientAddressDTO>> GetAddressFromCep(string cep);
        Task<Result> DeleteClientAddress(int id);
    }
}   