using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Domain.Entities
{
    public class Uuid
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string naam { get; set; }

        public string? nickname { get; set; }

        [Required]
        public string telefoon { get; set; }

        [Required]
        public string email { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
