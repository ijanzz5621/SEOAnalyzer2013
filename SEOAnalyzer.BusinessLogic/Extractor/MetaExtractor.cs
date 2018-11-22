using HtmlAgilityPack;
using SEOAnalyzer.BusinessLogic.Extractor.Interfaces;
using SEOAnalyzer.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Extractor
{
    public class MetaExtractor : IMetaExtractor
    {
        public string Content { get; set; }

        public List<MetaModel> GetMeta()
        {
            List<MetaModel> result = new List<MetaModel>();

            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(Content);

            var list = doc.DocumentNode.SelectNodes("//meta[@name='keywords']");
            //var list = doc.DocumentNode.SelectNodes("//meta");
            //int rowCount = 1;
            if (list != null)
            {
                foreach (var node in list)
                {
                    string content = node.GetAttributeValue("content", "");
                    result.Add(new MetaModel
                    {
                        Name = content.Replace(",", " , ") // To add space between commas so that it can wrap in the UI
                                                           //, Count = rowCount
                    });

                    //rowCount++;
                }
            }

            return result;
        }
    }
}
