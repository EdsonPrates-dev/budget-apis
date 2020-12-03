using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.User;
using Orcamento.Api.Models.User;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface IUserService
    {
        Task<Result<UserDTO>> GetUser(User user);
        Task CreateLoginFromContractor(User user, string cpfContractor);
    }
}