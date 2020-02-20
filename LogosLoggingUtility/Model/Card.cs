using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model
{
    public enum CardType
    {
        Support,
        Repair,
        Logs,
        Tech,
        Remote
    }

    public class Card
    {
        public string IconSource { get; set; }
        public string CardHeader { get; set; }
        public CardType Type { get; set; }
    }

    
}
