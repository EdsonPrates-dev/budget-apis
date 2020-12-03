using Orcamento.Api.DTO.Client;

namespace Orcamento.Api.DTO.Budget
{
    public class ClientDTO
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "cpf")]
        public string Cpf { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "phone")]
        public long Phone { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "clientAddress")]
        public ClientAddressDTO ClientAddress { get; set; }
    }
}
