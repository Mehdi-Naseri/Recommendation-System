using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSys.ViewModels
{
    public class UserSequence 
    {
        public int User { get; set; } = 0;
        public List<List<string>> Sequence { get; set; }
 }
}
