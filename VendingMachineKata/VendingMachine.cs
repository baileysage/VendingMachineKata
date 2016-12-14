using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public enum Coins
    {
        NICKELS,
        DIMES,
        QUARTERS,
        INVALID
    }
    public class VendingMachine
    {

        private int pop;
        private int chips;
        private int candy;
        private int[] coinsInKitty = { 10, 10, 10 };
        private int[] coinsDeposited = { 0, 0, 0 };
        private int[] coinReturn = { 0, 0, 0, 0 };
        private float amountDeposited = 0;

        public VendingMachine()
        {
            pop = 10;
            chips = 10;
            candy = 10;
        }

        public int coinCount(Coins coinType)
        {
            return coinsDeposited[(int)coinType];
        }

        public void InsertCoin(Coins coinType)
        {
            if (coinType != Coins.INVALID)
            {
                coinsDeposited[(int)coinType]++;
            }
            else
            {
                coinReturn[(int)coinType]++;
            }
        }
    }
}
