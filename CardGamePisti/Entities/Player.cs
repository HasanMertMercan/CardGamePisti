using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamePisti.Entities
{
    public class Player
    {
        public int PlayerNumber { get; set; }
        public List<Card> CardsInHand { get; set; }
        public List<Card> CollectedCards { get; set; }
        public Boolean IsTurn { get; set; }
    }
}
