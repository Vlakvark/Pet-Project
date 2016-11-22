using MTGCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCrawler
{
    public interface IMTGCrawler
    {
        IList<Card> FetchAll(string name);

        Card FetchDeckAndDice(string name);

        Card FetchDracoti(string name);

        Card FetchLuckShack(string name);

        Card FetchSadRobot(string name);

        Card FetchScry(string name);

        Card FetchTopDeck(string name);

        Card FetchUnderworldConnections(string name);
    }
}