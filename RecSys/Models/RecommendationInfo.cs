namespace RecSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class RecommendationInfo
    {
        [Key]
        [Required]
        public int RecId { get; set; }

        [StringLength(50)]
        public string RecName { get; set; }

        [ForeignKey("RecommendationInfoId")]
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}
