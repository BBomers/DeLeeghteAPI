using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Shared.DTOs.Weging
{
    public class WegingListItem
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("wedstrijd_id")]
        public int wedstrijd_id { get; set; }

        [JsonPropertyName("inschrijvingen_id")]
        public int inschrijvingen_id { get; set; }

        [JsonPropertyName("uuid_id")]
        public int uuid_id { get; set; }

        [JsonPropertyName("weging")]
        public double weging { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? updated_at { get; set; }
    }
}
