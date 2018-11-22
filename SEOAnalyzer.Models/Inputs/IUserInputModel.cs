using System.Collections.Generic;
using System.Web.Mvc;

namespace SEOAnalyzer.Models.Inputs
{
    public interface IUserInputModel
    {
        string InputType { get; set; }

        int[] SelectedOptions { get; set; }

        List<SelectListItem> AnalysisOptions { get; set; }

        string TextContent { get; set; }

        string UrlContent { get; set; }
    }
}