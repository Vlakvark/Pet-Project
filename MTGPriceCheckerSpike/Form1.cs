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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}