using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.Entities.Budget
{
    public class MaterialsBudget
    {
        [JsonIgnore]
        public int IdMaterials { get; set; }
        [JsonIgnore]
        public int IdClient { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }
}
