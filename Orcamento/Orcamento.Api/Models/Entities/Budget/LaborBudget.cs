using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.Entities.Budget
{
    public class LaborBudget
    {
        [JsonIgnore]
        public int IdLabor { get; set; }
        [JsonIgnore]
        public int IdClient { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
    }
}
