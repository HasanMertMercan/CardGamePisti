using CardGamePisti.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamePisti.Entities
{
    public class Card
    {
        public int Value { get; set; }
        public CardTypes CardTypes { get; set; }
        //future plan
        public string ImagePath { get; set; }
    }
}
