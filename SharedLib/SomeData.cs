using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [Serializable]
    public class SomeData : ISomeData
    {
        public string SomeProp { get; set; }
    }
}
