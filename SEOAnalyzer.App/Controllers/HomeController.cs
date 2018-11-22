using SEOAnalyzer.Domain.Seeds;
using SEOAnalyzer.Models;
using SEOAnalyzer.Models.Inputs;
using SEOAnalyzer.Models.Outputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SEOAnalyzer.BusinessLogic.Processor;
using SEOAnalyzer.BusinessLogic.Extractor;
using System.Threading.Tasks;

namespace SEOAnalyzer.App.Controllers
{
    public class HomeController : Controller
    {
        IProcessor gProcessor;

        public ActionResult Index()
        {
            ISEOViewModel model = new SEOViewModel(new UserInputModel(), new ResultModel());
            model.UserInputModel = new UserInputModel(new AnalysisOptions());
            //model.ResultModel = new ResultModel();
            return View(model);
        }

        /// <summary>
        /// Post Method to process user input (text or URL)
        /// Use algorithm to check and process the content of the text or URL
        /// </summary>
        /// <returns>
        /// The result of the text or URL from user for SEO
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> Index(SEOViewModel model)
        {
            // Call a business logic to check and process the input
            try
            {
                // Proceed if only the model is valid
                if (ModelState.IsValid)
                {
                    var directTextOption = model.UserInputModel.AnalysisOptions.Where(x => x.Value == "DirectText").FirstOrDefault();
                    if (directTextOption != null && directTextOption.Selected == true)
                    {
                        // Call a Text Processor
                        gProcessor = new TextProcessor(new LinkExtractor(), new HtmlExtractor(), new MetaExtractor());
                        model.ResultModel = await gProcessor.ProcessInput(model);
                        //model.ResultModel = gProcessor 

                    } else
                    {
                        // Call a Url Processor
                        gProcessor = new UrlProcessor(new LinkExtractor(), new HtmlExtractor(), new MetaExtractor());
                        model.ResultModel = await gProcessor.ProcessInput(model);
                    }
                    


                }
            }
            catch (Exception)
            {

                throw;
            }


            return View(model);
        }
    }
}