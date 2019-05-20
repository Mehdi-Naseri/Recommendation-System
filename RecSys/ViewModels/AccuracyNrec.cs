using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class AccuracyNrec
    {
        public float Precicion5 { get; set; }
        public float Recall5 { get; set; }
        public float F15 { get; set; }
        public float RecallwithFrequency5 { get; set; }
        public float F1withFrequency5 { get; set; }

        public float Precicion10 { get; set; }
        public float Recall10 { get; set; }
        public float F110 { get; set; }
        public float RecallwithFrequency10 { get; set; }
        public float F1withFrequency10 { get; set; }

        public float Precicion20 { get; set; }
        public float Recall20 { get; set; }
        public float F120 { get; set; }
        public float RecallwithFrequency20 { get; set; }
        public float F1withFrequency20 { get; set; }

        public float Precicion50 { get; set; }
        public float Recall50 { get; set; }
        public float F150 { get; set; }
        public float RecallwithFrequency50 { get; set; }
        public float F1withFrequency50 { get; set; }
    }
}
