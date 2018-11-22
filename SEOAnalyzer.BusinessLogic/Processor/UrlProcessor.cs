using SEOAnalyzer.BusinessLogic.Extractor.Interfaces;
using SEOAnalyzer.Models;
using SEOAnalyzer.Models.Generals;
using SEOAnalyzer.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Processor
{
    public class UrlProcessor : IProcessor
    {
        ILinkExtractor _linkExtractor;
        IHtmlExtractor _htmlExtractor;
        IMetaExtractor _metaExtractor;

        public string InputText { get; set; }

        public UrlProcessor(ILinkExtractor linkExtractor, IHtmlExtractor htmlExtractor, IMetaExtractor metaExtractor)
        {
            _linkExtractor = linkExtractor;
            _htmlExtractor = htmlExtractor;
            _metaExtractor = metaExtractor;
        }

        public async Task<IResultModel> ProcessInput(ISEOViewModel model)
        {
            IResultModel returnModel = new ResultModel();

            // 1. Extract Url link information from URL input
            List<LinkModel> links = _linkExtractor.GetLinkFromUrl(model.UserInputModel.UrlContent);
            returnModel.Links = links;

            // 2. Extract HTML
            returnModel.Content = await _htmlExtractor.GetContentFromUrl(model.UserInputModel.UrlContent);

            // 3. Get the META keywords
            _metaExtractor.Content = returnModel.Content;
            returnModel.Metas = _metaExtractor.GetMeta();

            // 4. Get words and its count
            returnModel.Keywords = _htmlExtractor.GetWordAndCount(model, _metaExtractor.Content);

            return returnModel;
        }
    }
}
