using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Budget;
using Mapper = Orcamento.Api.Service.MapperDTO.Mapper;

namespace Orcamento.Api.Service
{
    public class LaborBudgetService : ILaborBudgetService
    {
        private readonly ILaborBudgetRepository _laborBudgetRepository;
        private readonly IMapper _mapper;

        public LaborBudgetService(ILaborBudgetRepository laborBudgetRepository, IMapper mapper)
        {
            _laborBudgetRepository = laborBudgetRepository;
            _mapper = mapper;
        }

        public async Task<Result<LaborBudgetDTO>> CreateLaborBudget(LaborBudget laborBudget, string cpfClient)
        {
            var result = await _laborBudgetRepository.CreateLaborBudget(laborBudget, cpfClient);

            if (result.IsFailure)
                return Result.Failure<LaborBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result> DeleteLaborBudget(int idClient)
        {
            var result = await _laborBudgetRepository.DeleteLaborBudget(idClient);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return result;
        }

        public async Task<Result<LaborBudgetDTO>> GetLaborBudget(int idClient)
        {
            var result = await _laborBudgetRepository.GetLaborBudget(idClient);

            if (result.IsFailure)
                return Result.Failure<LaborBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<LaborBudgetDTO>> UpdateLaborBudget(LaborBudget laborBudget, string cpfClient)
        {
            var result = await _laborBudgetRepository.UpdateLaborBudget(laborBudget, cpfClient);

            if (result.IsFailure)
                return Result.Failure<LaborBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }
    }
}
