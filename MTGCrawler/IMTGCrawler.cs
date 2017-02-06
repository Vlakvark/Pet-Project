using MTGCrawler.Model;
using System.Collections.Generic;

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

        Card FetchBattleWizards(string name);
    }
}