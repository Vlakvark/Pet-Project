using MTGCrawler.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCrawler.Model
{
    public class Card
    {
        public string CardName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Supplier Supplier { get; set; }
    }
}