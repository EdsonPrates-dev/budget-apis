using AutoMapper;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.DTO.Client;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.DTO.User;
using Orcamento.Api.Models.Entities.Address;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Models.Entities.Contractors;
using Orcamento.Api.Models.User;

namespace Orcamento.Api.Infrastructure.AutoMapper
{
    public class ItemsMapper : Profile
    {
        public ItemsMapper()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientsAddress, ClientAddressDTO>();
            CreateMap<Contractor, ContractorDTO>();
            CreateMap<MaterialsBudget, MaterialsBudgetDTO>();
            CreateMap<LaborBudget, LaborBudgetDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<Address, ClientAddressDTO>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade));    
            
        }
    }
}
