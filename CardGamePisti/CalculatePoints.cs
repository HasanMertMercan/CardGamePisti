﻿using CardGamePisti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CardGamePisti.Enums;

namespace CardGamePisti
{
    public class CalculatePoints
    {
        private int[] result = new int[2];
        public CalculatePoints(List<Card> cardListPlayer1, List<Card> cardListPlayer2, int PistiCounterFirst, int PistiCounterSecond)
        {
            result = CalculateBiggerDeck(cardListPlayer1, cardListPlayer2);
            CalculatePistiPoints(PistiCounterFirst, PistiCounterSecond, result);
        }

        private void CalculatePistiPoints(int PistiCounterFirst, int PistiCounterSecond, int[] TotalResult)
        {
            int PointsFirst = PistiCounterFirst * 10;
            int PointsSecond = PistiCounterSecond * 10;
            TotalResult[0] = TotalResult[0] + PointsFirst;
            TotalResult[1] = TotalResult[1] + PointsSecond;
        }

        private int[] CalculateBiggerDeck(List<Card> cardListPlayer1, List<Card> cardListPlayer2)
        {
            int[] gameResult = new int[2];
            int cardList1Size = cardListPlayer1.Count;
            int cardList2Size = cardListPlayer2.Count;
            if(cardList1Size > cardList2Size)
            {
                gameResult[0] = Calculator(cardListPlayer1) + 3;
                gameResult[1] = Calculator(cardListPlayer2);
                return gameResult;
            }
            else if(cardList2Size > cardList1Size)
            {
                gameResult[0] = Calculator(cardListPlayer1);
                gameResult[1] = Calculator(cardListPlayer2) + 3;
                return gameResult;
            }
            else
            {
                gameResult[0] = Calculator(cardListPlayer1);
                gameResult[1] = Calculator(cardListPlayer2);
                return gameResult;
            }
        }

        private int Calculator(List<Card> cardList)
        {
            int TotalPoint = 0;
            int CardListSize = cardList.Count;
            for (int i = 0; i < CardListSize; i++)
            {
                switch (cardList[i].Value)
                {
                    case 11:
                        TotalPoint++;
                        break;
                    case 1:
                        TotalPoint++;
                        break;
                    default:
                        if(cardList[i].Value == 2 && cardList[i].CardTypes.Equals(CardTypes.Clubs))
                        {
                            TotalPoint = TotalPoint + 2;
                            break;
                        }
                        else if(cardList[i].Value == 10 && cardList[i].CardTypes.Equals(CardTypes.Diamonds))
                        {
                            TotalPoint = TotalPoint + 3;
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
            return TotalPoint;
        }

        public int[] GetResults()
        {
            return result;
        }

    }
}