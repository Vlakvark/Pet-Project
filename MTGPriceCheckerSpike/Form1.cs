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

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchDracoti(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchSadRobot(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchScry(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchTopDeck(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchLuckShack(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstCardResults.Clear();

            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchUnderworldConnections(textBox1.Text);
            lstCardResults.Items.Add("Price : " + card.Price.ToString());
            lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchAll(textBox1.Text);

            dataGridView1.DataSource = card;
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}