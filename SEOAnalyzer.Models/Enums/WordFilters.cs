using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models.Enums
{
    public class WordFilters
    {
        public List<string> StopWords { get; set; } 
        public WordFilters ()
	    {
            StopWords = new List<string>() {

                "AND", "OR", "A", "THE", "."

            };
	    }
    }
}
