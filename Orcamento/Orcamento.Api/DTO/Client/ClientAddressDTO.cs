using Orcamento.Api.DTO.Budget;

namespace Orcamento.Api.DTO.Client
{
    public class ClientAddressDTO
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "neighborhood")]
        public string Neighborhood { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cep")]
        public string Cep { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "client")]
        public ClientDTO Client { get; set; }
    }
}
