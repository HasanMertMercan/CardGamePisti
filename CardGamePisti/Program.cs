using CardGamePisti.Entities;
using System;
using System.Collections.Generic;

namespace CardGamePisti
{
    public class Program
    {
        public static Player FirstPlayer;
        public static Player SecondPlayer;
        public static Player ThirdPlayer;
        public static Player FourthPlayer;
        public static Player CurrentPlayer;
        public static Player NextPlayer;
        public static Card CurrentCard;

        public static List<Card> CardsInTheMiddle;
        public static List<Card> cardList = new List<Card>();
        public static List<Player> players;
        public static List<Card> FirstAndThirdPlayersCards;
        public static List<Card> SecondAndFourthPlayersCards;

        public static int FirstAndThirdPlayersPistiCounter;
        public static int SecondAndFourthPlayersPistiCounter;

        public static int[] GameResult;

        public static void Main(string[] args)
        {
            Initialize(); 
            CardController cardController = new CardController();
            cardList = cardController.getPlayingDeck();

            GameInitialization();
            while(!(cardList.Count == 0 && FirstPlayer.CardsInHand.Count == 0 && SecondPlayer.CardsInHand.Count == 0 &&
                    ThirdPlayer.CardsInHand.Count == 0 && FourthPlayer.CardsInHand.Count == 0))
            {
                Play();
            }

            FinishGame();

        }

        public static void Initialize()
        {
            Console.WriteLine("Initialize the cards and the players.");
            CardsInTheMiddle = new List<Card>();

            FirstPlayer = new Player();
            SecondPlayer = new Player();
            ThirdPlayer = new Player();
            FourthPlayer = new Player();
            CurrentPlayer = new Player();
            NextPlayer = new Player();
            CurrentCard = new Card();
            FirstAndThirdPlayersCards = new List<Card>();
            SecondAndFourthPlayersCards = new List<Card>();

            FirstAndThirdPlayersPistiCounter = 0;
            SecondAndFourthPlayersPistiCounter = 0;
            GameResult = new int[2];

            players = new List<Player> { FirstPlayer, SecondPlayer, ThirdPlayer, FourthPlayer };

            FirstPlayer.PlayerNumber = 1;
            SecondPlayer.PlayerNumber = 2;
            ThirdPlayer.PlayerNumber = 3;
            FourthPlayer.PlayerNumber = 4;
        }

        private static void Play()
        {
            //Find Player
            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].IsTurn == true)
                {
                    CurrentPlayer = players[i];
                    if(i+1 == players.Count)
                    {
                        NextPlayer = players[0];
                    }
                    else
                    {
                        NextPlayer = players[i + 1];
                    }
                    
                    Console.WriteLine("Current Player #" + i);
                    foreach (var card in CurrentPlayer.CardsInHand)
                    {
                        Console.Write(card.ToString() + ", ");
                    }

                    break;
                }
            }

            //Find Last Card and Play Accordingly
            int LastCardInList = CardsInTheMiddle.Count;
            if(LastCardInList > 0)
            {
                CurrentCard = CardsInTheMiddle[LastCardInList - 1];

                //if joker exists, keep its order.
                int ifJokerExists = -1;

                int count = 0;
                foreach (Card card in CurrentPlayer.CardsInHand)
                {
                    if (CurrentCard.Value == card.Value)
                    {
                        CardsInTheMiddle.Add(card);
                        CurrentPlayer.CardsInHand.Remove(card);
                        if(LastCardInList == 1)
                        {
                            if (CurrentPlayer.PlayerNumber == 1 || CurrentPlayer.PlayerNumber == 3)
                            {
                                FirstAndThirdPlayersPistiCounter++;
                                Console.WriteLine("First and Third Players Did Pisti");
                            }
                            else if (CurrentPlayer.PlayerNumber == 2 || CurrentPlayer.PlayerNumber == 4)
                            {
                                SecondAndFourthPlayersPistiCounter++;
                                Console.WriteLine("Second and Fourth Players Did Pisti");
                            }
                            NextPlayer.IsTurn = true;
                            CurrentPlayer.IsTurn = false;
                            break;
                        }
                        else
                        {
                            if (CurrentPlayer.PlayerNumber == 1 || CurrentPlayer.PlayerNumber == 3)
                            {
                                FirstAndThirdPlayersCards.AddRange(CardsInTheMiddle);
                                CardsInTheMiddle.RemoveRange(0, CardsInTheMiddle.Count);
                            }
                            else if (CurrentPlayer.PlayerNumber == 2 || CurrentPlayer.PlayerNumber == 4)
                            {
                                SecondAndFourthPlayersCards.AddRange(CardsInTheMiddle);
                                CardsInTheMiddle.RemoveRange(0, CardsInTheMiddle.Count);
                            }
                            NextPlayer.IsTurn = true;
                            CurrentPlayer.IsTurn = false;
                            break;
                        }
                    }
                    else if (card.Value == 11)
                    {
                        ifJokerExists = count;
                    }
                    count++;
                }

                if (!NextPlayer.IsTurn && ifJokerExists > -1)
                {
                    CardsInTheMiddle.Add(CurrentPlayer.CardsInHand[ifJokerExists]);
                    CurrentPlayer.CardsInHand.Remove(CurrentPlayer.CardsInHand[ifJokerExists]);
                    if (CurrentPlayer.PlayerNumber == 1 || CurrentPlayer.PlayerNumber == 3)
                    {
                        FirstAndThirdPlayersCards.AddRange(CardsInTheMiddle);
                        CardsInTheMiddle.RemoveRange(0, CardsInTheMiddle.Count);
                    }
                    else if (CurrentPlayer.PlayerNumber == 2 || CurrentPlayer.PlayerNumber == 4)
                    {
                        SecondAndFourthPlayersCards.AddRange(CardsInTheMiddle);
                        CardsInTheMiddle.RemoveRange(0, CardsInTheMiddle.Count);
                    }
                    NextPlayer.IsTurn = true;
                    CurrentPlayer.IsTurn = false;
                }
                else if (!NextPlayer.IsTurn && ifJokerExists == -1)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(0, CurrentPlayer.CardsInHand.Count);
                    CardsInTheMiddle.Add(CurrentPlayer.CardsInHand[index]);
                    CurrentPlayer.CardsInHand.Remove(CurrentPlayer.CardsInHand[index]);
                    NextPlayer.IsTurn = true;
                    CurrentPlayer.IsTurn = false;
                }

                if (NextPlayer.CardsInHand.Count == 0 && cardList.Count > 0)
                {
                    DistributeCards();
                }

            }
            else
            {
                Random rnd = new Random();
                int index = rnd.Next(0, CurrentPlayer.CardsInHand.Count);
                CardsInTheMiddle.Add(CurrentPlayer.CardsInHand[index]);
                CurrentPlayer.CardsInHand.Remove(CurrentPlayer.CardsInHand[index]);
                NextPlayer.IsTurn = true;
                CurrentPlayer.IsTurn = false;

                if (NextPlayer.CardsInHand.Count == 0 && cardList.Count > 0)
                {
                    DistributeCards();
                }
            }

            
            
            //for(int i = 0; i < CurrentPlayer.CardsInHand.Count; i++)
            //{
            //    if (CurrentCard.Value == CurrentPlayer.CardsInHand[i].Value)
            //    {
            //        CardsInTheMiddle.Add(CurrentPlayer.CardsInHand[i]);
            //        CurrentPlayer.CardsInHand.Remove(CurrentPlayer.CardsInHand[i]);
            //        NextPlayer.IsTurn = true;
            //        break;
            //    }
            //}

        }

        public static void FinishGame()
        {
            CalculatePoints calculatePoints = new CalculatePoints(FirstAndThirdPlayersCards, SecondAndFourthPlayersCards, FirstAndThirdPlayersPistiCounter, SecondAndFourthPlayersPistiCounter);
            GameResult = calculatePoints.GetResults();
            Console.WriteLine("First Team Score = " + GameResult[0]);
            Console.WriteLine("Second Team Score = " + GameResult[1]);
        }

        private static void GameInitialization()
        {
            Console.WriteLine("Deal the cards.");
            for (int j = 0; j < players.Count; j++)
            {
                List<Card> PlayersCards = new List<Card>();
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        
                        PlayersCards.Add(cardList[0]);
                        cardList.Remove(cardList[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
                players[j].CardsInHand = PlayersCards;


            }

            for (int i = 0; i < 4; i++)
            {
                CardsInTheMiddle.Add(cardList[0]);
                cardList.Remove(cardList[0]);
            }
            FirstPlayer.IsTurn = true;

        }

        private static void DistributeCards()
        {
            for (int j = 0; j < players.Count; j++)
            {
                List<Card> PlayersCards = new List<Card>();
                for (int i = 0; i < 4; i++)
                {
                    try
                    {

                        PlayersCards.Add(cardList[0]);
                        cardList.Remove(cardList[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
                players[j].CardsInHand = PlayersCards;


            }
        }
    }
}
