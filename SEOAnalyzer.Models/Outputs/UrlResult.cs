using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOAnalyzer.Models.Generals;

namespace SEOAnalyzer.Models.Outputs
{
    public class UrlResult : IResultModel
    {
        public string Content { get; set; }
        public List<MetaModel> Metas { get; set; }
        public List<KeywordModel> Keywords { get; set; }
        public List<LinkModel> Links { get; set; }


    }
}
