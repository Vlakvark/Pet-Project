using MTGCrawler.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MTGPriceCheckerSpike
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region WatchList

        private void btnWatchListAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> list = Properties.Settings.Default["WatchList"] as List<string>;
            if (list == null)
                list = new List<string>();

            list.Add(textBox1.Text);
            Properties.Settings.Default["WatchList"] = list;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            Cursor.Current = Cursors.Default;
        }

        private void btnWatchListRemove_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> list = Properties.Settings.Default["WatchList"] as List<string>;
            if (list == null)
                list = new List<string>();

            list.Remove(textBox1.Text);
            Properties.Settings.Default["WatchList"] = list;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            Cursor.Current = Cursors.Default;
        }

        private void btnWatchListView_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> list = Properties.Settings.Default["WatchList"] as List<string>;
            if (list == null)
            {
                MessageBox.Show("There is nothing in your watch list to view!");
                return;
            }

            lstCardResults.Clear();
            foreach (var item in list)
            {
                lstCardResults.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnWatchListCheck_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> list = Properties.Settings.Default["WatchList"] as List<string>;
            if (list == null)
                list = new List<string>();

            var cards = new List<Card>();
            foreach (var item in list)
            {
                MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
                var card = cr.FetchAll(item);
                cards.AddRange(card);
            }

            dataGridView1.DataSource = cards;
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Suppliers

        private void btnSupplierAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            var card = cr.FetchAll(textBox1.Text);

            dataGridView1.DataSource = card;
            Cursor.Current = Cursors.Default;
        }

        private void btnSupplierSingle_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lstCardResults.Clear();
            MTGCrawler.MTGCrawler cr = new MTGCrawler.MTGCrawler();
            Card card = null;

            switch (comboBox1.Text)
            {
                case "Dracoti":
                    card = cr.FetchDracoti(textBox1.Text);
                    break;
                case "Sad Robot":
                    card = cr.FetchSadRobot(textBox1.Text);
                    break;
                case "Top Deck":
                    card = cr.FetchTopDeck(textBox1.Text);
                    break;
                case "Deck and Dice":
                    card = cr.FetchDeckAndDice(textBox1.Text);
                    break;
                case "Scry":
                    card = cr.FetchScry(textBox1.Text);
                    break;
                case "Luck Shack":
                    card = cr.FetchLuckShack(textBox1.Text);
                    break;
                case "Underworld Connections":
                    card = cr.FetchUnderworldConnections(textBox1.Text);
                    break;
                case "CardBox":
                    card = cr.FetchCardBox(textBox1.Text);
                    break;
                case "Battle Wizards":
                    card = cr.FetchBattleWizards(textBox1.Text);
                    break;
            }

            if (card != null)
            {
                lstCardResults.Items.Add("Price : " + card.Price.ToString());
                lstCardResults.Items.Add("Availability : " + card.Stock.ToString());
            }
            else
            {
                lstCardResults.Items.Add("No Results Found for Card");
            }
            Cursor.Current = Cursors.Default;
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}