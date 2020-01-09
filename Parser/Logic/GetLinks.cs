using HtmlAgilityPack;
using Parser.DataBase;
using Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Parser.Logic
{
    public class GetLinks
    {
        private readonly AppDBContent _db;

        public GetLinks(AppDBContent db)
        {
            _db = db;
        }
        public static List<string> GetAllLinks(string url, int depth, List<string> list)
        {
            
            using (var client = new WebClient())
            {
                var htmlSource = client.DownloadString(url);
                foreach (var item in GetLinksFromWebsite(htmlSource))
                {                    
                    //body.Url = item;
                    //body.Body = htmlSource;
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<string> GetLinksFromWebsite(string htmlSource)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            return doc
                .DocumentNode
                .SelectNodes("//a[@href]")
                .Select(node => node.Attributes["href"].Value)
                .ToList();
        }
    }
}
