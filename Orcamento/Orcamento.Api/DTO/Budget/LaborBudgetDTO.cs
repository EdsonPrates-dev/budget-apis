using Orcamento.Api.DTO.Contractor;

namespace Orcamento.Api.DTO.Budget
{
    public class LaborBudgetDTO
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "costPrice")]
        public decimal CostPrice { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "client")]
        public ClientDTO Client { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "contractor")]
        public ContractorDTO Contractor { get; set; }
    }
}
