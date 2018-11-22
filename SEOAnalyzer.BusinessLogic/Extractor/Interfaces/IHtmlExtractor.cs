using SEOAnalyzer.Models;
using SEOAnalyzer.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Extractor.Interfaces
{
    public interface IHtmlExtractor : IExtractor
    {
        Task<string> GetContentFromUrl(string url);
        List<KeywordModel> GetWordAndCount(ISEOViewModel model, string content);
    }
}
