using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models.Generals
{
    interface IKeyword
    {
        string Name { get; set; }
        int WordCount { get; set; }
    }
}
