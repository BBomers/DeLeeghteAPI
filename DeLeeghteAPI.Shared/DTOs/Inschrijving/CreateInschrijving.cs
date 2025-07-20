using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Shared.DTOs.Inschrijving
{
    public class CreateInschrijving
    {

        [JsonPropertyName("wedstrijd_id")]
        public int wedstrijd_id { get; set; }

        [JsonPropertyName("uuid_id")]
        public int uuid_id { get; set; }

        [JsonPropertyName("stek")]
        public int? stek { get; set; }

        [JsonPropertyName("uuid_id_two")]
        public int? uuid_id_two { get; set; }

        [JsonPropertyName("stek_two")]
        public int? stek_two { get; set; }

        [JsonPropertyName("uuid_id_tree")]
        public int? uuid_id_tree { get; set; }

        [JsonPropertyName("stek_tree")]
        public int? stek_tree { get; set; }

        [JsonPropertyName("uuid_id_four")]
        public int? uuid_id_four { get; set; }

        [JsonPropertyName("stek_four")]
        public int? stek_four { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? updated_at { get; set; }
    }
}
