using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class ItemRating
    {
        public string ItemId { get; set; }
        public float Rating { get; set; }

        public ItemRating(string ItemId , float Rating )
        {
            this.ItemId = string.Copy(ItemId);
            this.Rating = Rating;
        }

        public ItemRating()
        {
        }
    }
}
