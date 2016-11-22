using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGCrawler
{
    public static class StringExtension
    {
        private const string _regEx = "[^0-9.]";

        public static decimal ToDecimal(this string value)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-GB");
            var style = NumberStyles.Number;
            var rgx = new Regex(_regEx);
            decimal price = 0;
            var str = Regex.Replace(value, _regEx, "");
            str = str.Replace("...", "");
            Decimal.TryParse(str, style, culture, out price);

            return price;
        }

        public static int ToInt(this string value)
        {
            var rgx = new Regex(_regEx);
            int stock = 0;
            int.TryParse(rgx.Replace(value, ""), out stock);

            return stock;
        }
    }
}