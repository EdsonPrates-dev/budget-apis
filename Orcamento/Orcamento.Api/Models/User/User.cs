using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Orcamento.Api.Models.User
{
    public class User
    {
        [JsonIgnore]
        public int IdUser { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int IdContractor { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
