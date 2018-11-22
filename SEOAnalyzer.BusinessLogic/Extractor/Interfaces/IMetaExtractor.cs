using SEOAnalyzer.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Extractor.Interfaces
{
    public interface IMetaExtractor : IExtractor
    {
        string Content { get; set; }

        List<MetaModel> GetMeta();
    }
}
