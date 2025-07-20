using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Shared.DTOs.Uuid
{
    public class UuidListItem
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("naam")]
        public string naam { get; set; }
        [JsonPropertyName("nickname")]
        public string? nickname { get; set; }

        [JsonPropertyName("telefoon")]
        public string telefoon { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? updated_at { get; set; }
    }
}
