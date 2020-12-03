using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orcamento.Api.DTO.Contractor
{
    public class ContractorDTO
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "cpf")]
        public string Cpf { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "phone")]
        public long Phone { get; set; }
    }
}
