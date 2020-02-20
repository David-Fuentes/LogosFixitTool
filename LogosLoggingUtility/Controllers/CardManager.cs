using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Controllers
{
    public static partial class CardManager
    {

        public static Dictionary<CardType,Card> GetCardByCardType()
        {
            var defaultIconSource = "/Images/DefaultIcon.png";
            var cards = new Dictionary<CardType, Card>();
            var supportInfoCard = new Card
            {
                IconSource = defaultIconSource,
                CardHeader = "Support Info",
                Type = CardType.Support
            };

            var repairCard = new Card
            {
                IconSource = defaultIconSource,
                CardHeader = "Repair Logos/Verbum",
                Type = CardType.Repair
            };

            var logCard = new Card
            {
                IconSource = defaultIconSource,
                CardHeader = "Logging",
                Type = CardType.Logs
            };

            var techCard = new Card
            {
                IconSource = defaultIconSource,
                CardHeader = "Tech Tools",
                Type = CardType.Tech
            };

            var remoteCard = new Card
            {
                IconSource = defaultIconSource,
                CardHeader = "Remote Control",
                Type = CardType.Remote
            };

            cards.Add(CardType.Support, supportInfoCard);
            cards.Add(CardType.Repair, repairCard);
            cards.Add(CardType.Logs, logCard);
            cards.Add(CardType.Tech, techCard);
            cards.Add(CardType.Remote, remoteCard);

            return cards;
        }
    }
}
