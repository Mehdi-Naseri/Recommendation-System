using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class UserItemRating
    {
        public int UserId { get; set; }
        public string ItemId { get; set; }
        public float Rating { get; set; } = 0;

        public UserItemRating(int UserId, string ItemId , float Rating )
        {
            this.UserId = UserId;
            this.ItemId = string.Copy(ItemId);
            this.Rating = Rating;
        }

        public UserItemRating()
        {
        }
    }
}
