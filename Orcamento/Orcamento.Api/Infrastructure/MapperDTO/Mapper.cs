using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.DTO.Client;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.DTO.User;
using Orcamento.Api.Models.Entities.Address;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Models.Entities.Contractors;
using Orcamento.Api.Models.User;

namespace Orcamento.Api.Service.MapperDTO
{
    public static class Mapper
    {
        public static UserDTO Map(User user, IMapper _mapper) => _mapper.Map<UserDTO>(user);

        public static Result<ClientAddressDTO> Map(ClientsAddress clientsAddress, IMapper _mapper) => _mapper.Map<ClientAddressDTO>(clientsAddress);
        public static Result<ClientAddressDTO> MapAddress(Address address, IMapper _mapper) => _mapper.Map<ClientAddressDTO>(address);     
        public static Result<ClientDTO> Map(Client client, IMapper _mapper) => _mapper.Map<ClientDTO>(client);
        public static Result<ContractorDTO> Map(Contractor contractor, IMapper _mapper) => _mapper.Map<ContractorDTO>(contractor);
        public static Result<LaborBudgetDTO> Map(LaborBudget laborBudget, IMapper _mapper) => _mapper.Map<LaborBudgetDTO>(laborBudget);
        public static Result<MaterialsBudgetDTO> Map(MaterialsBudget materialsBudget, IMapper _mapper) => _mapper.Map<MaterialsBudgetDTO>(materialsBudget);
    }
}
