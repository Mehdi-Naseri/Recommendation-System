using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.ViewModels
{
    public class WeightAccuracyNrec
    {
        
        public int PurchaseWeight { get; set; }

        public int CollaborativeNotPurcasedWeight { get; set; }

        public int SpmPurchasedWeight { get; set; }

        public int SpmNotPurchasedWeight { get; set; }

        public AccuracyNrec AccuracyNrec { get; set; }
    }
}
