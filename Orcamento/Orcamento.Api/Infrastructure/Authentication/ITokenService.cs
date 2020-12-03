using Orcamento.Api.Models.User;

namespace Orcamento.Api.Infrastructure.Authentication
{
    public interface ITokenService
    {
        TokenResponse GenerateToken(User user);
    }
}