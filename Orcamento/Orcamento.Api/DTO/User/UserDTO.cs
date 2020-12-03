using System;
using System.Text.Json.Serialization;

namespace Orcamento.Api.DTO.User
{
    public class UserDTO
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
