using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGPriceCheckerSpike
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("http://dracoti.co.za/product/" + cardName.Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    //var specificNode = doc.GetElementbyId("main-fullwidth");
                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[5]/div/div/div[2]/div[1]/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[5]/div/div/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(59, priceXPath[0].InnerHtml.Length - 59);
                        // var availability = availabilityXPath[0].InnerHtml.Substring(61, priceXPath[0].InnerHtml.Length);
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add("Availability : " + availabilityXPath[0].InnerHtml);
                        ///html/body/div[1]/div[5]/div/div/div[2]/p
                        //availability
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("http://sadrobot.co.za/shop/" + cardName.Replace("'", "").Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[3]/div/div[1]/div[2]/div/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[3]/div/div[2]/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5);
                        // var availability = availabilityXPath[0].InnerHtml.Substring(61, priceXPath[0].InnerHtml.Length);
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add("Availability : " + availabilityXPath[0].InnerHtml);
                        ///html/body/div[1]/div[5]/div/div/div[2]/p
                        //availability
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("http://scry.co.za/index.php?route=product/search&search=" + cardName);

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[6]/div/div[5]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[6]/div/div[3]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5).Replace(Environment.NewLine, "").Replace(" ", "");
                        var availability = availabilityXPath[0].InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add(availability);
                    }
                    else
                    {
                        lstCardResults.Items.Add("Price : None Available");
                        lstCardResults.Items.Add("Availability : 0");
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("https://store.topdecksa.co.za/products/" + cardName.Replace("'", "").Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div[1]/div[4]/div/div[2]/table/tr[2]/td[2]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div[1]/div[4]/div/div[2]/table/tr[2]/td[3]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerHtml.Substring(5, priceXPath[0].InnerHtml.Length - 5).Replace(Environment.NewLine, "").Replace(" ", "");
                        var availability = availabilityXPath[0].InnerHtml.Replace(Environment.NewLine, "").Replace(" ", "");
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add("Availability : " + availability);
                    }
                    else
                    {
                        lstCardResults.Items.Add("Price : None Available");
                        lstCardResults.Items.Add("Availability : 0");
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("http://luckshack.co.za/index.php?main_page=advanced_search_result&search_in_description=1&zenid=stgAGm0muOSnQhb28QQmY3&keyword=" + cardName.Replace(' ', '+'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[4]/div/table/tr/td[3]/table/tr/td[1]/div[2]/div[1]/table/tr[2]/td[5]");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/body/div/div[4]/div/table/tr/td[3]/table/tr/td[1]/div[2]/div[1]/table/tr[2]/td[4]");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerText.Replace("Add:", "");
                        var availability = availabilityXPath[0].InnerText;
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add("Availability : " + availability);
                    }
                    else
                    {
                        lstCardResults.Items.Add("Price : None Available");
                        lstCardResults.Items.Add("Availability : 0");
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = textBox1.Text;

                    var html = client.DownloadString("http://underworldconnections.co.za/product/" + cardName.Replace(' ', '-'));

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    //var specificNode = doc.GetElementbyId("main-fullwidth");
                    var priceXPatwh = doc.DocumentNode.ChildNodes;

                    var priceXPath = doc.DocumentNode.SelectNodes("/html/html/body/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/p/span");
                    var availabilityXPath = doc.DocumentNode.SelectNodes("/html/html/body/div[2]/div[2]/div/div/div[2]/div[2]/p");

                    if (priceXPath != null && priceXPath.Count() > 0)
                    {
                        var price = priceXPath[0].InnerText.Substring(5, priceXPath[0].InnerText.Length - 5);
                        // var availability = availabilityXPath[0].InnerHtml.Substring(61, priceXPath[0].InnerHtml.Length);
                        lstCardResults.Items.Add("Price : " + price);
                        lstCardResults.Items.Add("Availability : " + availabilityXPath[0].InnerText);
                        ///html/body/div[1]/div[5]/div/div/div[2]/p
                        //availability
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add("Price : None Available");
                    lstCardResults.Items.Add("Availability : 0");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();
            using (var client = new WebClient())
            {
                try
                {
                    var cardName = string.Format("\"{0}\"", textBox1.Text);
                    // initial request to get search results
                    var html = client.DownloadString(string.Format("https://app.ecwid.com/rpc/7080336/5?7080336||0.5194191513943245|23.3-1664-g52d06e6!9f6c220d*7|1|14|https://app.ecwid.com/|F913A30B232D1B24A063AAA4BE361ADB|_|searchProducts|1t|1m|java.util.Map|1l|java.util.List|Z|7c|I|{0}|2a|1|2|3|4|10|5|6|6|7|8|9|10|11|12|12|13|0|0|14|0|0|0|0|0|11|0|0|10|", cardName.Replace(" ", "%20")));

                    // now we need to seacrh for pattern in this string
                    if (html.ToLowerInvariant().Contains(textBox1.Text))
                    {
                        // they have the card, now find the details
                        System.Text.RegularExpressions.Regex searchTerm = new System.Text.RegularExpressions.Regex(@",\d{1,4}.\d{1},1,\d{8}");
                        var results = searchTerm.Matches(html);
                        if (results.Count > 0)
                        {
                            var infos = results[results.Count - 1].Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var price = infos[0];
                            //var html2 = client.DownloadString(string.Format("https://app.ecwid.com/rpc/7080336/3?7080336||0.9064937051798795|23.3-1664-g52d06e6!f3c49182*7|1|7|https://app.ecwid.com/|F913A30B232D1B24A063AAA4BE361ADB|_|getOriginalProduct|3x|I|Z|1|2|3|4|3|5|6|7|0|{0}|0|", useThis));

                            lstCardResults.Items.Add("Price : " + price);
                            lstCardResults.Items.Add("Availability : At least 1");
                        }
                        else
                        {
                            lstCardResults.Items.Add("Price : None Available");
                            lstCardResults.Items.Add("Availability : 0");
                        }
                    }
                    else
                    {
                        lstCardResults.Items.Add("Price : None Available");
                        lstCardResults.Items.Add("Availability : 0");
                    }
                }
                catch (Exception ex)
                {
                    lstCardResults.Items.Add("Price : None Available");
                    lstCardResults.Items.Add("Availability : 0");
                }
            }
        }
    }
}