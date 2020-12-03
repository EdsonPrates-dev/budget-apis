using Orcamento.Api.DTO.Contractor;

namespace Orcamento.Api.DTO.Budget
{
    public class MaterialsBudgetDTO
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "costPrice")]
        public decimal CostPrice { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "client")]
        public ClientDTO Client { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "contractor")]
        public ContractorDTO Contractor { get; set; }
    }
}
