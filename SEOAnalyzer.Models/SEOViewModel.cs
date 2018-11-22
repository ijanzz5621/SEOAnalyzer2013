using SEOAnalyzer.Models.Inputs;
using SEOAnalyzer.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models
{
    public class SEOViewModel : ISEOViewModel
    {
        public IUserInputModel UserInputModel { get; set; }
        public IResultModel ResultModel { get; set; }

        public SEOViewModel()
        {
            UserInputModel = new UserInputModel();
            ResultModel = new ResultModel();

        }

        public SEOViewModel(IUserInputModel _userInputModels, IResultModel _resultModel)
        {
            UserInputModel = _userInputModels;
            //ResultModel = _resultModel;
        }
    }
}
