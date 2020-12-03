using CSharpFunctionalExtensions;
using Orcamento.Api.Models.User;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public interface IUserRepository
    {
        Task<Result<User>> GetUser(User user);
        Task CreateLoginFromContractor(User user, string cpfContractor);
    }
}