using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Domain.Entities
{
    public class Weging
    {
        [Key]
        public int id { get; set; }


        [Required]
        public int wedstrijd_id { get; set; }

        [Required]
        public int inschrijvingen_id { get; set; }

        [Required]
        public int uuid_id { get; set; }

        [Required]
        public double weging { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }

}
