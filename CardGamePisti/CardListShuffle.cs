using CardGamePisti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGamePisti
{
    public class CardListShuffle
    {
        private static Random rng = new Random();

        public void Shuffle(List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
