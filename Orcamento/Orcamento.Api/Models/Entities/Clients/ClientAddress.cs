using System;
using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.Entities.Clients
{
    public class ClientsAddress
    {
        [JsonIgnore]
        public int IdAddress { get; set; }
        public int IdClient { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Cep { get; set; }
        
    }
}
