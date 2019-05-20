using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class SequenceSupportPercentage /*: List<ItemFrequency>*/
    {
        public List<List<string>> sequence { get; set; }
        public int support { get; set; } = 0;

        public float supportPercentage { get; set; } = 0;
    }
}
