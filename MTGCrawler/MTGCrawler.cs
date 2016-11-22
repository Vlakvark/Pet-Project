using MTGCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGCrawler
{
    public class MTGCrawler : IMTGCrawler
    {
        private const string _regEx = "[^a-zA-Z0-9 -]";

        public Card FetchDracoti(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0
            };

            using (var client = new WebClient())
            {
                var rgx = new Regex(_regEx);
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
                        var availability = availabilityXPath[0].InnerHtml;

                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }

                return card;
            }
        }

        public Card FetchLuckShack(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0
            };

            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("http://luckshack.co.za/index.php?main_page=advanced_search_result&search_in_description=1&zenid=stgAGm0muOSnQhb28QQmY3&keyword=" + name.Replace(' ', '+'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[4]/div/table/tr/td[3]/table/tr/td[1]/div[2]/div[1]/table/tr[2]/td[5]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[4]/div/table/tr/td[3]/table/tr/td[1]/div[2]/div[1]/table/tr[2]/td[4]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerText.Replace("Add:", "");
                        var availability = availabilityXPath[0].InnerText;

                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }

                return card;
            }
        }

        public Card FetchSadRobot(string name)
        {
            var card = new Card()
            {
                CardName = name
            };

            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("http://sadrobot.co.za/shop/" + name.Replace("'", "").Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[3]/div/div[1]/div[2]/div/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[3]/div/div[2]/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5);
                        var availability = availabilityXPath[0].InnerHtml;

                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return card;
        }

        public Card FetchScry(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0
            };

            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("http://scry.co.za/index.php?route=product/search&search=" + name);

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[6]/div/div[5]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[6]/div/div[3]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5).Replace(Environment.NewLine, "").Replace(" ", "");
                        var availability = availabilityXPath[0].InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");
                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }

                return card;
            }
        }

        public Card FetchTopDeck(string name)
        {
            var card = new Card()
            {
                CardName = name
            };
            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("https://store.topdecksa.co.za/products/" + name.Replace("'", "").Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div[1]/div[4]/div/div[2]/table/tr[2]/td[2]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div[1]/div[4]/div/div[2]/table/tr[2]/td[3]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5).Replace('\n', ' ').Replace(" ", "");
                        var availability = availabilityXPath[0].InnerHtml.Replace(Environment.NewLine, "").Replace(" ", "");
                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }

                return card;
            }
        }

        public Card FetchUnderworldConnections(string name)
        {
            var card = new Card()
            {
                CardName = name
            };

            using (var client = new WebClient())
            {
                try
                {
                    var html = client.DownloadString("http://underworldconnections.co.za/product/" + name.Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPatwh = doc.DocumentNode.ChildNodes;

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/html/body/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/html/body/div[2]/div[2]/div/div/div[2]/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerText.Substring(5, priceXPath[0].InnerText.Length - 5);
                        var availability = availabilityXPath[0].InnerText;
                        card.Price = price.ToDecimal();
                        card.Stock = availability.ToInt();
                    }
                }
                catch (Exception ex)
                {
                }
                return card;
            }
        }
    }
}