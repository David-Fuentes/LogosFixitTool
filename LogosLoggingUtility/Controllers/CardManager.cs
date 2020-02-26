using LogosLoggingUtility.Model;
using System.Collections.Generic;

namespace LogosLoggingUtility.Controllers
{
    public static partial class CardManager
    {
        public static Dictionary<CardType, Card> GetCardInfoByCardType()
        {
            return CardInfoByCardType;
        }

        private static Dictionary<CardType, Card> CardInfoByCardType = new Dictionary<CardType, Card>()
        {
            { CardType.Support, new Card() {IconSource = "/Images/IconHeaderSupport.png", CardHeader = "Support Info", Type = CardType.Support }},

            { CardType.Repair, new Card() {IconSource = "/Images/IconHeaderRepair.png", CardHeader = "Repair Logos/Verbum", Type = CardType.Repair}},

            { CardType.Logs, new Card() {IconSource = "/Images/IconHeaderLog.png", CardHeader = "Logging", Type = CardType.Logs}},

            { CardType.Tech,new Card() {IconSource = "/Images/IconHeaderTech.png", CardHeader = "Tech Tools", Type = CardType.Tech}},

            { CardType.Remote, new Card() {IconSource = "/Images/IconHeaderRemote.png", CardHeader = "Remote Control", Type = CardType.Remote}}
        };

        public static Dictionary<CardType, CardDescription> CardDescriptionByCardType = new Dictionary<CardType, CardDescription>()
        {
            {CardType.Logs ,
                new CardDescription()
                {
                    CardInfo = "Enable and disable logs. Logs can also be archived to the default location of your desktop" ,
                    Features = new List<Feature>()
                    {
                        new Feature("Enable Logs", "you know, enabling the logs"),
                        new Feature( "Disable Logs", "oh yes" ),
                        new Feature("Archive Logs", "good stuff" )
                    }
                }}
        };
    }

    public class CardDescription
    {
        public string CardInfo;
        public List<Feature> Features;
    }

    public class Feature
    {
        public Feature(string name, string description)
        {
            FeatureName = name;
            FeatureDescription = description;
        }
        public string FeatureName;
        public string FeatureDescription;
    }
}
