using CardGamePisti.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamePisti.Entities
{
    class Card
    {
        public int Value { get; set; }
        public CardTypes cardTypes { get; set; }
        public string ImagePath { get; set; }
    }
}
