using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class Accuracy
    {
        public float Precicion { get; set; }
        public float Recal { get; set; }

        public float F1 { get; set; }

        public float RecalwithFrequency { get; set; }

        public float F1withFrequency { get; set; }
    }
}
