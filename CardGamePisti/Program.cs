using CardGamePisti.Entities;
using System;
using System.Collections.Generic;

namespace CardGamePisti
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardList = new List<Card>();
            CardController cardController = new CardController();
            cardList = cardController.getPlayingDeck();


        }
    }
}
