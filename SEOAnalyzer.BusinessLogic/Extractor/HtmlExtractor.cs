using SEOAnalyzer.BusinessLogic.Extractor.Interfaces;
using SEOAnalyzer.Models;
using SEOAnalyzer.Models.Enums;
using SEOAnalyzer.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEOAnalyzer.BusinessLogic.Extractor
{
    public class HtmlExtractor : IHtmlExtractor
    {
        //public string UrlPath { get; set; }

        public async Task<string> GetContentFromUrl(string url)
        {
            WebClient client = new WebClient();
            string rtnString = "";
            try
            {
                rtnString = await client.DownloadStringTaskAsync(url);
            }
            catch (WebException)
            {
            }

            return rtnString;
        }

        public List<KeywordModel> GetWordAndCount(ISEOViewModel model,  string content)
        {
            List<KeywordModel> returnData = new List<KeywordModel>();
            bool removeStopWord = false;
            // Check if user select to filter stop words
            var stopWordsOption = model.UserInputModel.AnalysisOptions.Where(x => x.Value == "StopWords").FirstOrDefault();
            if (stopWordsOption != null && stopWordsOption.Selected == true)
            {
                removeStopWord = true;
            }

            string[] words = Regex.Replace(content, "<.*?>", String.Empty).Split(' ');
            //string[] words = content.Replace("<", " ").Replace(">", " ").Replace("</", " ").Split(' ');
            foreach (string word in words)
            {
                string newWord = word.Trim();
                if (newWord != "" && IsAWord(newWord) && !newWord.Any(c => char.IsDigit(c)))
                {
                    WordFilters wf = new WordFilters();
                    if (removeStopWord == true && wf.StopWords.Any(s => s.ToUpper().Contains(newWord.ToUpper())))
                    {
                        // ignore and dont add
                    } else
                    {
                        var checkData = returnData.Where(x => x.Name == newWord).FirstOrDefault();
                        if (checkData == null)
                        {
                            returnData.Add(new KeywordModel
                            {
                                Name = newWord
                                ,
                                WordCount = 1
                            });
                        }
                        else
                        {
                            checkData.WordCount++;
                        }
                    }

                }
            }

            return returnData;
        }

        public static bool IsAWord(string text)
        {
            var regex = new Regex(@"\b[\w']+\b");
            var match = regex.Match(text);
            return match.Value.Equals(text);
        }
    }
}
