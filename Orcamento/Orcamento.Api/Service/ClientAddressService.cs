using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Client;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Clients;
using System.Threading.Tasks;
using Mapper = Orcamento.Api.Service.MapperDTO.Mapper;


namespace Orcamento.Api.Service.Interfaces
{
    public class ClientAddressService : IClientAddressService
    {
        private readonly IClientAddressRepository _clientAddressRepository;
        private readonly IMapper _mapper;

        public ClientAddressService(IClientAddressRepository clientAddressRepository, IMapper mapper)
        {
            _clientAddressRepository = clientAddressRepository;
            _mapper = mapper;
        }

        public async Task<Result<ClientAddressDTO>> CreateClientAddress(ClientsAddress clientAddress)
        {         
           var result = await _clientAddressRepository.CreateClientAddress(clientAddress);

            if (result.IsFailure)
                return Result.Failure<ClientAddressDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<ClientAddressDTO>> UpdateClientAddress(ClientsAddress ClientAddress)
        {
            var result = await _clientAddressRepository.UpdateClientAddress(ClientAddress);

            if (result.IsFailure)
                return Result.Failure<ClientAddressDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result> DeleteClientAddress(int id)
        {
            var result = await _clientAddressRepository.DeleteClientAddress(id);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return result;
        } 

        public async Task<Result<ClientAddressDTO>> GetClientAddress(int id)
        {
            var result = await _clientAddressRepository.GetClientAddress(id);

            if (result.IsFailure)
                return Result.Failure<ClientAddressDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<ClientAddressDTO>> GetAddressFromCep(string cep)
        {
            var result = await _clientAddressRepository.GetAddressFromCep(cep);

            if (result.IsFailure)
                return Result.Failure<ClientAddressDTO>(result.Error);

            return Mapper.MapAddress(result.Value, _mapper);
        }
    }
}
