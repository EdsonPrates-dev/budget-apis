using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.Entities.Contractors
{
    public class Contractor
    {
        [JsonIgnore]
        public int IdContractor { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public long Phone { get; set; }
    }
}
