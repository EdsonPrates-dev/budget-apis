using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Contractors;
using Mapper = Orcamento.Api.Service.MapperDTO.Mapper;

namespace Orcamento.Api.Service
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly IMapper _mapper;

        public ContractorService(IContractorRepository contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<Result<ContractorDTO>> CreateContractor(Contractor contractor)
        {
            var result = await _contractorRepository.CreateContractor(contractor);

            if (result.IsFailure)
                return Result.Failure<ContractorDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result> DeleteContractor(string cpf)
        {
            var result = await _contractorRepository.DeleteContractor(cpf);

            if (result.IsFailure)
                return Result.Failure<ContractorDTO>(result.Error);

            return result;
        }

        public async Task<Result<ContractorDTO>> GetContractor(int id)
        {
            var result = await _contractorRepository.GetContractor(id);

            if (result.IsFailure)
                return Result.Failure<ContractorDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<ContractorDTO>> UpdateContractor(Contractor contractor)
        {
            var result = await _contractorRepository.UpdateContractor(contractor);

            if (result.IsFailure)
                return Result.Failure<ContractorDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

    }
}
