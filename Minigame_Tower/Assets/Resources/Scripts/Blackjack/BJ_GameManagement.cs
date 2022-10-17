using System;
using System.Collections.Generic;


namespace BlackJack // 클래스들을 그룹별로 묶어서 더 체계적으로 관리하기 위해서...
{
    class BJ_GameManagement 
    {
        private int numberOfDecks; // 덱의 숫자
        private BJ_Deck deck = null; // 덱의 값
        private BJ_Player player = null; // 플레이어 설정

       
        public void FillDeck()
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                deck.Fill("Diamonds", deck);
                deck.Fill("Spades", deck);
                deck.Fill("Clubs", deck);
                deck.Fill("Hearts", deck);
            }
        }

        /// <summary>
        /// returns the deck (list of) being used
        /// </summary>
        /// <returns></returns>
        public BJ_Deck GetDeckList()
        {
            return deck;
        }

        /// <summary>
        /// define the number of decks, in case we want to add more
        /// </summary>
        /// <param name="num"></param>
        public void SetNumberOfDecks(int num)
        {
            numberOfDecks = num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BJ_Card GetCard()
        {
            Random rng = new Random();
            int cardCount = deck.GetCardCount();
            BJ_Card cardToReturn;

            //checks the count total to know if we return a random card, the last card or none
            if (cardCount > 2)
            {
                cardToReturn = deck.GetDeck()[rng.Next(1, cardCount)];
                deck.GetDeck().Remove(cardToReturn);
                return cardToReturn;
            }
            else if (cardCount == 1)
            {
                cardToReturn = deck.GetDeck()[1];
                deck.GetDeck().Remove(cardToReturn);
                return cardToReturn;
            }
            else
            {
                return null;
            }
        }

        public BJ_Player GetPlayer()
        {
            return player;
        }
    }
}