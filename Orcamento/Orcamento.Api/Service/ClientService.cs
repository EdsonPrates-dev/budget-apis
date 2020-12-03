using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Clients;
using Mapper = Orcamento.Api.Service.MapperDTO.Mapper;

namespace Orcamento.Api.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Result<ClientDTO>> CreateClient(Client client)
        {
            var result = await _clientRepository.CreateClient(client);

            if (result.IsFailure)
                return Result.Failure<ClientDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }           

        public async Task<Result> DeleteClient(string cpf)
        {
            var result = await _clientRepository.DeleteClient(cpf);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return result;
        }

        public async Task<Result<IEnumerable<ClientDTO>>> GetAllClients()
        {
            var listMapped = new List<ClientDTO>();
            var listClients = await _clientRepository.GetAllClients();

            if (listClients.IsFailure)
                return Result.Failure<IEnumerable<ClientDTO>>(listClients.Error);

            listClients.Value.AsParallel()
                .ForAll(client => 
                {
                    listMapped.Add(Mapper.Map(client, _mapper).Value);
                });

            return listMapped;
        }          

        public async Task<Result<ClientDTO>> GetClient(string cpf, bool budgets)
        {
            var result = await _clientRepository.GetClient(cpf, budgets);

            if (result.IsFailure)
                return Result.Failure<ClientDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<ClientDTO>> UpdateClient(Client client)
        {
            var result = await _clientRepository.UpdateClient(client);

            if (result.IsFailure)
                return Result.Failure<ClientDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<ClientDTO>> GetClientWithAddress(string cpf)
        {
            var result = await _clientRepository.GetClientWithAddress(cpf);

            if (result.IsFailure)
                return Result.Failure<ClientDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }
    }
}
