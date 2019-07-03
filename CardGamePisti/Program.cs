using CardGamePisti.Entities;
using System;
using System.Collections.Generic;

namespace CardGamePisti
{
    public class Program
    {
        public static List<Card> CardsInTheMiddle;
        public static Player FirstPlayer;
        public static Player SecondPlayer;
        public static Player ThirdPlayer;
        public static Player FourthPlayer;

        public static List<Card> cardList;
        public static List<Player> players;

        public static void Main(string[] args)
        {
            Initialize(); 
            CardController cardController = new CardController();
            cardList = cardController.getPlayingDeck();

            GameInitialization(cardList, players, CardsInTheMiddle);
            Play(players, CardsInTheMiddle);
        }

        public static void Initialize()
        {
            CardsInTheMiddle = new List<Card>();

            FirstPlayer = new Player();
            SecondPlayer = new Player();
            ThirdPlayer = new Player();
            FourthPlayer = new Player();

            cardList = new List<Card>();

            players = new List<Player> { FirstPlayer, SecondPlayer, ThirdPlayer, FourthPlayer };
        }

        public static void Play(List<Player> players, List<Card> CardsInTheMiddle)
        {

        }

        private static void GameInitialization(List<Card> cardList, List<Player> players, List<Card> CardsInTheMiddle)
        {
            for (int j = 0; j < players.Count; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    players[j].CardsInHand[i] = cardList[0];
                    cardList.Remove(cardList[0]);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                CardsInTheMiddle[i] = cardList[0];
                cardList.Remove(cardList[0]);
            }

        }

        private void DistributeCards(List<Card> cardList, List<Player> players)
        {
            for (int j = 0; j < players.Count; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    players[j].CardsInHand[i] = cardList[0];
                    cardList.Remove(cardList[0]);
                }
            }
        }
    }
}
