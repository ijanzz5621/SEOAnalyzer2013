using SEOAnalyzer.Models;
using SEOAnalyzer.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Processor
{
    public interface IProcessor
    {
        string InputText { get; set; }

        Task<IResultModel> ProcessInput(ISEOViewModel model);
    }
}
