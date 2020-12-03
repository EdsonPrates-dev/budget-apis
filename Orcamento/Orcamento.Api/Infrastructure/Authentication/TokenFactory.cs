using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Orcamento.Api.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Orcamento.Api.Infrastructure.Authentication
{
    public class TokenFactory : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string secret;
        private readonly string issuer;

        public TokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            secret = _configuration.GetSection("JWT")["secret_token"];
            issuer = _configuration.GetSection("JWT")["Issuer"];
        }

        public TokenResponse GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Iss, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var dt = DateTime.Now;
            var expirationDate = dt.AddMinutes(30);
            var token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: expirationDate,
                signingCredentials: creds);

            return new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = token.ValidFrom
            };
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

