using MTGCrawler.Model;
using MTGCrawler.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGCrawler
{
    public class MTGCrawler : IMTGCrawler
    {
        private const string _regEx = "[^a-zA-Z0-9 -]";

        public IList<Card> FetchAll(string name)
        {
            var suppliers = EnumToList<Supplier>();

            var supplierResults = new List<Card>();

            Parallel.ForEach(suppliers, supplier =>
            {
                switch (supplier)
                {
                    case Supplier.DeckAndDice:
                        supplierResults.Add(FetchDeckAndDice(name));
                        break;

                    case Supplier.Dracoti:
                        supplierResults.Add(FetchDracoti(name));
                        break;

                    case Supplier.LuckShack:
                        supplierResults.Add(FetchLuckShack(name));
                        break;

                    case Supplier.TopDeck:
                        supplierResults.Add(FetchTopDeck(name));
                        break;

                    case Supplier.UnderworldConnections:
                        supplierResults.Add(FetchUnderworldConnections(name));
                        break;

                    case Supplier.SadRobot:
                        supplierResults.Add(FetchSadRobot(name));
                        break;

                    case Supplier.Scry:
                        supplierResults.Add(FetchScry(name));
                        break;

                    case Supplier.BattleWizards:
                        supplierResults.Add(FetchBattleWizards(name));
                        break;

                    default:
                        break;
                }
            });

            return supplierResults;
        }

        public Card FetchDeckAndDice(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0,
                Supplier = Supplier.DeckAndDice
            };

            using (var client = new WebClient())
            {
                try
                {
                    var cardName = string.Format("\"{0}\"", name);
                    // initial request to get search results
                    var html = client.DownloadString(string.Format("https://app.ecwid.com/rpc/7080336/10?7080336||0.58501668835575|23.9-373-g5bf8e52!10bdf368*7|1|14|https://app.ecwid.com/|F61A1BD152F3F909A2F5B4B947BF5A00|_|searchProducts|1u|1m|java.util.Map|1l|java.util.List|Z|7o|I|{0}|2b|1|2|3|4|10|5|6|6|7|8|9|10|11|12|12|13|0|0|14|0|0|0|0|0|11|0|0|60|", cardName.Replace(" ", "%20")));
                    //https://app.ecwid.com/rpc/7080336/5?7080336||0.5194191513943245|23.3-1664-g52d06e6!9f6c220d*7|1|14|https://app.ecwid.com/|F913A30B232D1B24A063AAA4BE361ADB|_|searchProducts|1t|1m|java.util.Map|1l|java.util.List|Z|7c|I|{0}|2a|1|2|3|4|10|5|6|6|7|8|9|10|11|12|12|13|0|0|14|0|0|0|0|0|11|0|0|10|
                    //https://app.ecwid.com/rpc/7080336/10?7080336||0.58501668835575|23.9-373-g5bf8e52!10bdf368*7|1|14|https://app.ecwid.com/|F61A1BD152F3F909A2F5B4B947BF5A00|_|searchProducts|1u|1m|java.util.Map|1l|java.util.List|Z|7o|I|{0}|2b|1|2|3|4|10|5|6|6|7|8|9|10|11|12|12|13|0|0|14|0|0|0|0|0|11|0|0|60|
                    // now we need to seacrh for pattern in this string
                    if (html.ToLowerInvariant().Contains(name))
                    {
                        // they have the card, now find the details
                        System.Text.RegularExpressions.Regex searchTerm = new System.Text.RegularExpressions.Regex(@",\d{1,4}.\d{1},1,\d{8}");
                        var results = searchTerm.Matches(html);
                        if (results.Count > 0)
                        {
                            var infos = results[results.Count - 1].Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var price = infos[0];
                            //var html2 = client.DownloadString(string.Format("https://app.ecwid.com/rpc/7080336/3?7080336||0.9064937051798795|23.3-1664-g52d06e6!f3c49182*7|1|7|https://app.ecwid.com/|F913A30B232D1B24A063AAA4BE361ADB|_|getOriginalProduct|3x|I|Z|1|2|3|4|3|5|6|7|0|{0}|0|", useThis));

                            card.Price = price.ToDecimal();
                            card.Stock = 1;
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }

            return card;
        }

        public Card FetchDracoti(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0,
                Supplier = Supplier.Dracoti
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

        //http://www.battlewizards.co.za/search?q=fatal+push

        public Card FetchLuckShack(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0,
                Supplier = Supplier.LuckShack
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
                Stock = 0,
                Price = 0,
                CardName = name,
                Supplier = Supplier.SadRobot
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
                Price = 0,
                Supplier = Supplier.Scry
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
                Stock = 0,
                Price = 0,
                CardName = name,
                Supplier = Supplier.TopDeck
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
                Stock = 0,
                Price = 0,
                CardName = name,
                Supplier = Supplier.UnderworldConnections
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

        public Card FetchBattleWizards(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0,
                Supplier = Supplier.BattleWizards
            };

            using (var client = new WebClient())
            {
                var rgx = new Regex(_regEx);
                try
                {
                    var html = client.DownloadString("http://www.battlewizards.co.za/search?q=" + name.Replace(' ', '+'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[3]/main/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[3]/main/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/p/strong");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Replace("ZAR", "");
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

        public Card FetchCardBox(string name)
        {
            var card = new Card()
            {
                CardName = name,
                Stock = 0,
                Price = 0,
                Supplier = Supplier.CardBox
            };

            //using (var client = new WebClient())
            //{
            //    var rgx = new Regex(_regEx);
            //    try
            //    {
            //        var html = client.DownloadString("http://www.cardbox.co.za/index.php?ajx=result_qfind&qfind=" + name);

            //        var doc = new HtmlAgilityPack.HtmlDocument();
            //        doc.LoadHtml(html);

            //        var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[3]/main/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/p/span");
            //        var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[3]/main/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/p/strong");

            //        if (priceXPath != null && priceXPath.Count() > 0)
            //        {
            //            var price = priceXPath[0].InnerHtml.Replace("ZAR", "");
            //            var availability = availabilityXPath[0].InnerHtml;

            //            card.Price = price.ToDecimal();
            //            card.Stock = availability.ToInt();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //    }                
            //}

            return card;
        }

        private IList<T> EnumToList<T>()
        {
            var types = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return types;
        }
    }
}