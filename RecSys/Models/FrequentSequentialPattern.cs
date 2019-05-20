using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.Models
{
    //[Table("FrequentSequentialPattern2items-10Months")]
    [Table("FrequentSequentialPattern-11Month")]
    public class FrequentSequentialPattern
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Sequence { get; set; }

        [Required]
        public int Support { get; set; }
    }
}
