using System.Collections.Generic;
using System.Web.Mvc;

namespace SEOAnalyzer.Domain.Seeds
{
    public interface IAnalysisOptions
    {
        //List<string> Options { get; set; }

        List<SelectListItem> GetOptions();
    }
}