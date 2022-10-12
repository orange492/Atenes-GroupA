using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack // 네임스페이스는 클래스들을 그룹별로 묶어서 더 체계적으로 관리하기 위한것
{
    class BlackjackManager
    {
        private int numberOfDecks;
        private Deck deck = null; // 덱에 있는거 이용
        private Player player = null; // 플레이어에 있는거 이용

        public BlackjackManager()
        {
            
        }

        public void FillDeck() // 덱채우기
        {
           
        }

     
        public Deck GetDeckList() //덱에서 리스트 읽어오기
        {
            return deck;
        }

       
        public void SetNumberOfDecks(int num) // 덱의 수 설정하기
        {
            numberOfDecks = num;
        }

     
    
        public Player GetPlayer() 
        {
            return player;
        }
    }
}