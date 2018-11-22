using SEOAnalyzer.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models.Outputs
{
    public interface IResultModel
    {
        string Content { get; set; }
        List<MetaModel> Metas { get; set; }
        List<KeywordModel> Keywords { get; set; }
        List<LinkModel> Links { get; set; }

    }
}
