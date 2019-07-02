using CardGamePisti.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamePisti
{
    class CardController
    {
        private List<Card> playingDeck = new List<Card>();

        private List<Card> CreatePlayingDeck()
        {
            List<Card> cardList = new List<Card>();

            Card card = new Card();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        card.Value = j;
                        card.cardTypes = Enums.CardTypes.Clubs;
                        cardList.Add(card);
                    }
                }
                else if (i == 1)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        card.Value = j;
                        card.cardTypes = Enums.CardTypes.Diamonds;
                        cardList.Add(card);
                    }
                }
                else if (i == 2)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        card.Value = j;
                        card.cardTypes = Enums.CardTypes.Hearts;
                        cardList.Add(card);
                    }
                }
                else if (i == 3)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        card.Value = j;
                        card.cardTypes = Enums.CardTypes.Spades;
                        cardList.Add(card);
                    }
                }
            }

            CardListShuffle shuffle = new CardListShuffle();
            shuffle.Shuffle(cardList);
            return cardList;
        }

        public List<Card> getPlayingDeck()
        {
            playingDeck = CreatePlayingDeck();
            return playingDeck;
        }
      
        


    }
}
