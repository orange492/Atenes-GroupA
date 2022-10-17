using System;
using System.Collections.Generic;


namespace BlackJack // 클래스들을 그룹별로 묶어서 더 체계적으로 관리하기 위해서...
{
    class BJ_Card
    {
        private string suit;
        private char suitAbreviation;
        private string cardValue;

        // ====== CONSTRUCTORS ======
        public BJ_Card()
        {
            SetSuit("");
            SetSuitAbreviation(' ');
            SetCardValue("");
        }

        public BJ_Card(string suit, char abb, string value)
        {
            SetSuit(suit);
            SetSuitAbreviation(abb);
            SetCardValue(value);
        }

        // ====== GETTERS/SETTERS ======

        public string GetSuit()
        {
            return suit;
        }

        public void SetSuit(string value)
        {
            suit = value;
        }


        public char GetSuitAbreviation()
        {
            return suitAbreviation;
        }

        public void SetSuitAbreviation(char value)
        {
            suitAbreviation = value;
        }

        public string GetCardValue()
        {
            return cardValue;
        }

        public void SetCardValue(string value)
        {
            cardValue = value;
        }

       
    }
}
