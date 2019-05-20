using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class ItemSupport /*: List<ItemFrequency>*/
    {
        [Key, Column(Order = 0)]
        public string Item { get; set; }
        public int Support { get; set; } = 0;

        //private IEnumerator GetEnumerator()
        //{
        //    return (IEnumerator)this;
        //}


    }
}
