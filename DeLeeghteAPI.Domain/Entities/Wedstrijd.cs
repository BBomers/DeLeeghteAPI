using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DeLeeghteAPI.Domain.Entities
{
    public class Wedstrijd
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string naam { get; set; }
        [Required]
        public int categorie_id { get; set; }
        public bool? zichtbaarheid { get; set; }
        [Required]
        public DateTime date { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
