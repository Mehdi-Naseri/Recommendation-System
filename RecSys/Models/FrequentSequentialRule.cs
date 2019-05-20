using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.Models
{
    public class FrequentSequentialRule
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Sequence1 { get; set; }

        [Required]
        public string Sequence2 { get; set; }

        [Required]
        public int Support { get; set; }

        [Required]
        public float Confidence { get; set; }
    }
}
