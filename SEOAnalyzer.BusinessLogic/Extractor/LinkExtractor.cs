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
    public class LinkExtractor : ILinkExtractor
    {
        public string UrlPath { get; set; }

        public List<LinkModel> GetLinkFromUrl(string url)
        {
            List<LinkModel> returnList = new List<LinkModel>();

            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(url);
            //HtmlNodeCollection nodesLink = doc.DocumentNode.SelectNodes("//a[@href]");

            //if (nodesLink != null)
            //{
            //    foreach (HtmlNode link in nodesLink)
            //    {
            //        var newItem = new LinkModel
            //        {
            //            Name = link.Name
            //            ,
            //            Path = link.XPath
            //        };
            //        returnList.Add(newItem);
            //    }
            //}

            var linkedPages = doc.DocumentNode.Descendants("a")
                                  .Select(a => a.GetAttributeValue("href", null))
                                  .Where(u => !String.IsNullOrEmpty(u));
            if (linkedPages != null)
            {
                foreach (string link in linkedPages)
                {
                    var newItem = new LinkModel
                    {
                        Name = link
                        //,
                        //Path = link.XPath
                    };
                    returnList.Add(newItem);
                }
            }
            return returnList;
        }

        public List<LinkModel> GetLinkFromContent(string content)
        {
            List<LinkModel> returnList = new List<LinkModel>();

            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);

            var linkedPages = doc.DocumentNode.Descendants("a")
                                  .Select(a => a.GetAttributeValue("href", null))
                                  .Where(u => !String.IsNullOrEmpty(u));
            if (linkedPages != null)
            {
                foreach (string link in linkedPages)
                {
                    var newItem = new LinkModel
                    {
                        Name = link
                        //,
                        //Path = link.XPath
                    };
                    returnList.Add(newItem);
                }
            }
            return returnList;
        }
    }
}
