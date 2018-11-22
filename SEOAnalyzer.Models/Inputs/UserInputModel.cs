using SEOAnalyzer.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SEOAnalyzer.Models.Inputs
{
    public class UserInputModel : IUserInputModel
    {
        public string InputType { get; set; }

        public List<SelectListItem> AnalysisOptions { get; set; }

        //[Required]
        [AllowHtml]
        public string TextContent { get; set; }
        public string UrlContent { get; set; }

        public int[] SelectedOptions { get; set; }

        /// <summary>
        /// Default Class constructor 
        /// </summary>
        public UserInputModel()
        {
            InputType = "";
            TextContent = "";
            UrlContent = "";
        }

        /// <summary>
        /// Class constructor with parameter
        /// </summary>
        /// <param name="analysisOptions"></param>
        public UserInputModel(IAnalysisOptions analysisOptions)
        {
            AnalysisOptions = analysisOptions.GetOptions();
        }
    }
}
