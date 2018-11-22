using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models.Outputs
{
    public abstract class BaseResult
    {
        public string Content { get; set; }
        public List<string> Metas { get; set; }
        public int MyProperty { get; set; }
    }
}
