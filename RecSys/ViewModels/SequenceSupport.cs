using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class SequenceSupport 
    {

        public List<List<string>> sequence { get; set; }
        public int support { get; set; } = 0;
    }
}
