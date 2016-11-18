using MTGCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTGCrawler
{
    public class MTGCrawler : IMTGCrawler
    {
        public Card FetchDracoti(string name)
        {
            var card = new Card()
            {
                CardName = name
            };

            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("http://dracoti.co.za/product/" + name.Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[5]/div/div/div[2]/div[1]/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[5]/div/div/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(59, priceXPath[0].InnerHtml.Length - 59);
                        // var availability = availabilityXPath[0].InnerHtml.Substring(61, priceXPath[0].InnerHtml.Length);
                        // lstCardResults.Items.Add("Price : " + price);
                        //  lstCardResults.Items.Add("Availability : " + availabilityXPath[0].InnerHtml);
                        ///html/body/div[1]/div[5]/div/div/div[2]/p
                        //availability
                    }
                }
                catch (Exception ex)
                {
                    //    lstCardResults.Items.Add(ex.Message);
                }

                return card;
            }
        }

        public Card FetchLuckShack(string name)
        {
            throw new NotImplementedException();
        }

        public Card FetchSadRobot(string name)
        {
            var card = new Card()
            {
                CardName = name
            };

            return card;
        }

        public Card FetchScry(string name)
        {
            throw new NotImplementedException();
        }

        public Card FetchTopDeck(string name)
        {
            throw new NotImplementedException();
        }

        public Card FetchUnderworldConnections(string name)
        {
            throw new NotImplementedException();
        }
    }
}