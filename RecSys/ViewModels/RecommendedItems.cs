using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class RecommendedItems
    {
        [Key]
        public int User { get; set; }
        public IList<ItemRating> Items { get; set; }
    }
}
