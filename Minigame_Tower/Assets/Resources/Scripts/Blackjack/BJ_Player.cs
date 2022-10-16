using System;
using System.Collections.Generic;


namespace BlackJack // 클래스들을 그룹별로 묶어서 더 체계적으로 관리하기 위해서...
{
    class BJ_Player
    {
        private string name;
        private double bank;

        

        public BJ_Player(string name, double bank)
        {
            SetName(name);
            SetBank(bank);
        }

        // ====== GETTERS / SETTERS ======
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
       
        public double GetBank()
        {
            return bank;
        }

        public void SetBank(double bank)
        {
            this.bank = bank;
        }
    }
}
