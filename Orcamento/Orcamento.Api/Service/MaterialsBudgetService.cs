using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Budget;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Budget;
using Mapper = Orcamento.Api.Service.MapperDTO.Mapper;

namespace Orcamento.Api.Service
{
    public class MaterialsBudgetService : IMaterialsBudgetService
    {
        private readonly IMaterialsBudgetRepository _materialsBudgetRepository;
        private readonly IMapper _mapper;

        public MaterialsBudgetService(IMaterialsBudgetRepository materialsBudgetRepository, IMapper mapper)
        {
            _materialsBudgetRepository = materialsBudgetRepository;
            _mapper = mapper;
        }

        public async Task<Result<MaterialsBudgetDTO>> CreateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient)
        {
            var result = await _materialsBudgetRepository.CreateMaterialsBudget(materialsBudget, cpfClient);

            if (result.IsFailure)
                return Result.Failure<MaterialsBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result> DeleteMaterialsBudget(int idClient)
        {
            var result = await _materialsBudgetRepository.DeleteMaterialsBudget(idClient);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return result;
        }

        public async Task<Result<MaterialsBudgetDTO>> GetMaterialsBudget(int idClient)
        {
            var result = await _materialsBudgetRepository.GetMaterialsBudget(idClient);

            if (result.IsFailure)
                return Result.Failure<MaterialsBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }

        public async Task<Result<MaterialsBudgetDTO>> UpdateMaterialsBudget(MaterialsBudget materialsBudget, string cpfClient)
        {
            var result = await _materialsBudgetRepository.UpdateMaterialsBudget(materialsBudget, cpfClient);

            if (result.IsFailure)
                return Result.Failure<MaterialsBudgetDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }
    }
}
