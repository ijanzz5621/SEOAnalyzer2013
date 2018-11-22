using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models.Outputs
{
    public interface ITextResult
    {
        string TextName { get; set; }
        int NumberOfOccurence { get; set; }
        bool IsFilterWord { get; set; }
    }
}
