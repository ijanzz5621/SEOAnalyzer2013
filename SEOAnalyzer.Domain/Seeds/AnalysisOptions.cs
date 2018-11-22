using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SEOAnalyzer.Domain.Seeds
{
    public class AnalysisOptions : IAnalysisOptions
    {
        //public List<string> Options { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<SelectListItem> GetOptions()
        {
            SelectListGroup group = new SelectListGroup();
            group.Name = "AnalysisOptions";
            return new List<SelectListItem>
            {

                new SelectListItem { Text = "Remove Stop Words", Value = "StopWords", Group = group }
                , new SelectListItem { Text = "Direct Text", Value = "DirectText", Group = group }
            };
        }
    }
}
