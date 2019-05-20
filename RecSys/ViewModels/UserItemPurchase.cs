using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class UserItemPurchase
    {
        public int User { get; set; }
        public string Item { get; set; }

        public UserItemPurchase(int user, string item)
        {
            User = user;
            Item = string.Copy(item);
        }

        public UserItemPurchase()
        {
        }
    }
}
