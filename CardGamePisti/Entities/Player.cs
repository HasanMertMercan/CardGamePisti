using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamePisti.Entities
{
    class Player
    {
        int PlayerNumber { get; set; }
        List<Card> cardsInHand { get; set; }
        List<Card> collectedCards { get; set; }
    }
}
