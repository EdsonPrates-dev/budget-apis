using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.Models.Entities.Contractors;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface IContractorService
    {
        Task<Result<ContractorDTO>> CreateContractor(Contractor contractor);
        Task<Result<ContractorDTO>> UpdateContractor(Contractor contractor);
        Task<Result<ContractorDTO>> GetContractor(int id);
        Task<Result> DeleteContractor(string cpf);
    }
}