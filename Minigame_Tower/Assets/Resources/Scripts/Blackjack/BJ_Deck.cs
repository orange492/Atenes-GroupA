using System;
using System.Collections.Generic;


namespace BlackJack // 클래스들을 그룹별로 묶어서 더 체계적으로 관리하기 위해서...
{
    class BJ_Deck 
    {
        private short numberOfCards = 0;
            
        private List<BJ_Card> deckOfCards = null;

        public BJ_Deck()
        {
            numberOfCards = 52;
            deckOfCards = new List<BJ_Card>();
        }

        public BJ_Deck(short numOfCards)
        {
            numberOfCards = numOfCards;
            deckOfCards = new List<BJ_Card>();
        }


        // MANIPULATING THE DECK OF CARDS
        public void AddCard(BJ_Card card)
        {
            if(numberOfCards > 0)
            {
                deckOfCards.Add(card);
                numberOfCards -= 1;
            }
        }

        public void RemoveCard(BJ_Card card)
        {
            deckOfCards.Remove(card);          
        }

        public List<BJ_Card> GetDeck()
        {
            return this.deckOfCards;
        }

        public int GetCardCount()
        {
            return deckOfCards.Count;
        }

        /// <summary>
        /// Used to fill the deck with the cards corresponding to the respective suit
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="deck"></param>
        public void Fill(string suit, BJ_Deck deck)
        {
            char suitAbv = DefineSuit(suit);

            for(int i = 2; i < 11; i++)
            {
                deck.AddCard(new BJ_Card(suit, suitAbv, i.ToString()));
            }
          
            deck.AddCard(new BJ_Card(suit, suitAbv, "J"));
            deck.AddCard(new BJ_Card(suit, suitAbv, "Q"));
            deck.AddCard(new BJ_Card(suit, suitAbv, "K"));
            deck.AddCard(new BJ_Card(suit, suitAbv, "A"));
        }

        /// <summary>
        /// Returns the abbreviation of the suit
        /// </summary>
        /// <param name="suit"></param>
        /// <returns></returns>
        private char DefineSuit(string suit)
        {
            if (suit.Equals("Clubs"))
            {
                return 'C';
            }

            if (suit.Equals("Diamonds"))
            {
                return 'D';
            }

            if (suit.Equals("Spades"))
            {
                return 'S';
            }

            if (suit.Equals("Hearts"))
            {
                return 'H';
            }

            return ' ';
        }
    }
}
