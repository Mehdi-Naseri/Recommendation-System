using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class UserItemlist
    {
        public int UserId { get; set; }
        public List<string> Items { get; set; }
 }
}
