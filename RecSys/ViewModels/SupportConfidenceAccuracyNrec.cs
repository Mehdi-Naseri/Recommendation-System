using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class SupportConfidenceAccuracyNrec
    {
        
        public float Support { get; set; }

        public float Confidence { get; set; }

        public AccuracyNrec AccuracyNrec { get; set; }
    }
}
