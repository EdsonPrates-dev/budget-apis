using Orcamento.Api.Models.Entities.Budget;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.Entities.Clients
{
    public class Client
    {

        [JsonIgnore]
        public int IdClient { get; set; }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        [NotMapped]
        public ClientsAddress ClientAddress { get; set; }
        [JsonIgnore]
        [NotMapped]
        public LaborBudget LaborBudget { get; set; }
        [JsonIgnore]
        [NotMapped]
        public MaterialsBudget MaterialsBudget { get; set; }

        public void MapClientAddress(ClientsAddress clientsAddress)
        {
            ClientAddress = clientsAddress;
        }

        public void MapClientAddress(ClientsAddress clientsAddress,
            LaborBudget laborBudget, MaterialsBudget materialsBudget)
        {
            ClientAddress = clientsAddress;
            LaborBudget = laborBudget;
            MaterialsBudget = materialsBudget;
        }
    }
}
