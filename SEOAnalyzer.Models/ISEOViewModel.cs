using SEOAnalyzer.Models.Inputs;
using SEOAnalyzer.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models
{
    public interface ISEOViewModel
    {
        IUserInputModel UserInputModel { get; set; }
        IResultModel ResultModel { get; set; }
    }
}
