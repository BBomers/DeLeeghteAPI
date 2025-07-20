using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Domain.Entities
{
    public class Inschrijving
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int wedstrijd_id { get; set; }

        [Required]
        public int uuid_id { get; set; }

        public int? stek { get; set; }

        public int? uuid_id_two { get; set; }

        public int? stek_two { get; set; }

        public int? uuid_id_tree { get; set; }

        public int? stek_tree { get; set; }

        public int? uuid_id_four { get; set; }

        public int? stek_four { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }

}
