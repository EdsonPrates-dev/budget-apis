using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.Contractor;
using Orcamento.Api.Models.Entities.Contractors;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Repository
{
    public interface IContractorRepository
    {
        Task<Result<Contractor>> CreateContractor(Contractor contractor);
        Task<Result<Contractor>> UpdateContractor(Contractor contractor);
        Task<Result<Contractor>> GetContractor(int id);
        Task<Result> DeleteContractor(string cpf);
    }
}