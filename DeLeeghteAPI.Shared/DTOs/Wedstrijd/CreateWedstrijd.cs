using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Shared.DTOs.Wedstrijd
{
    public class CreateWedstrijd
    {

        [JsonPropertyName("naam")]
        public string naam { get; set; }

        [JsonPropertyName("categorie_id")]
        public int categorie_id { get; set; }

        [JsonPropertyName("zichtbaarheid")]
        public bool? zichtbaarheid { get; set; }

        [JsonPropertyName("date")]
        public DateTime date { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? updated_at { get; set; }
    }
}
