using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class ProductsSimilarity
    {
        public string Product1 { get; set; }
        public string Product2 { get; set; }
        //Similarity between 0 & 100
        public float Similarity { get; set; }
    }
}
